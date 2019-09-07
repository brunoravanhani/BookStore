import React, { Component } from 'react';
import moment from 'moment';
import * as Api from '../../services/livroApi';
import * as AutorApi from '../../services/autorApi';
import * as GeneroApi from '../../services/generoApi';
import * as EditoraApi from '../../services/editoraApi';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input, Row, Col } from 'reactstrap';

export class Livro extends Component {

  state = {
    modal: false,
    livros: [],
    livroEscolhido: null,
    titulo: '',
    descricao: '',
    sinopse: '',
    link: '',
    paginas: 0,
    imagemCapa: '',
    dataPublicacao: null,
    idEditora: null,
    idAutor: null,
    idGenero: null,
    autores: [],
    generos: [],
    editoras: []
  }

  async componentDidMount() {
    this.fetchLivros();
    this.fetchCamposAuxiliares();
  }

  fetchLivros = async () => {
    const livros = await Api.buscar();
    this.setState({livros});
  }

  fetchCamposAuxiliares = async () => {
    const autores = await AutorApi.buscar();
    const editoras = await EditoraApi.buscar();
    const generos = await GeneroApi.buscar();
    this.setState({autores, editoras, generos});
  }

  onChange = (e) => {
    const {name, value} = e.target;
    
    const newState = {};
    newState[name] = value;
    this.setState({...newState});
  }

  
  salvar = async () => {
    const {idLivro, titulo} = this.state;

    if (titulo && titulo !== '') {

      const livro = {
        titulo: this.state.titulo,
        descricao: this.state.descricao,
        sinopse: this.state.sinopse,
        paginas: this.state.paginas,
        idAutor: this.state.idAutor,
        idEditora: this.state.idEditora,
        idGenero: this.state.idGenero,
        dataPublicacao: formatarData(this.state.dataPublicacao),
        imagemCapa: null,
        link: this.state.link
      };

      if (!idLivro) {
        await Api.novo({...livro});
      } else {
        await Api.atualizar({...livro, idLivro});
      }
      this.fetchLivros();
      this.toggleModal();
    }
  }

  excluir = async (id) => {
    await Api.excluir(id);
    this.fetchLivros();
  }
  
  abrirModalNovo = () => {
    this.setState({
    });
    this.toggleModal();
  }

  abrirModalEdicao = (id) => {
    const livro = this.state.livros.find(x => x.idLivro === id);
    this.setState({
      livroEscolhido: livro,
      idLivro: livro.idLivro,
      titulo: livro.titulo,
      descricao: livro.descricao,
      sinopse: livro.sinopse,
      paginas: livro.paginas,
      link: livro.link,
      dataPublicacao: moment(livro.dataPublicacao).format('YYYY-MM-DD'),
      idAutor: livro.idAutor,
      idEditora: livro.idEditora,
      idGenero: livro.idGenero,
    });
    this.toggleModal();
  }
  cancelar = () => {
    this.setState( {
    });
    this.toggleModal();
  }

  toggleModal = () => {
    this.setState(prevState => ({
      modal: !prevState.modal
    }));
  }

  renderLivro = (livro, index) => {
    return (
      <tr key={index}>
        <td style={{width: '80%'}}>
          {livro.titulo}
        </td>
        <td>
          <Button outline color="primary" onClick={() => this.abrirModalEdicao(livro.idLivro)}>Editar</Button>{' '}
          <Button outline color="danger" onClick={() => this.excluir(livro.idLivro)}>Excluir</Button>
        </td>
      </tr>
    );
  }

  render () {
    return (
      <div>
        <h1>Livros Cadastrados</h1>
        
        <div style={{marginBottom: 10}}>
          <Button color="primary" onClick={this.abrirModalNovo}>Cadastrar Novo</Button>
        </div>

        <table className='table table-striped'>
          <thead>
            <tr>
              <th>Título</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {(this.state.livros || []).map(this.renderLivro)}
          </tbody>
        </table>

        <Modal isOpen={this.state.modal} toggleModal={this.cancelar} >
          <ModalHeader toggleModal={this.cancelar}>Cadastrar Livro</ModalHeader>
          <ModalBody>
            <Form>
              <FormGroup>
                <Label for="titulo">Título</Label>
                <Input type="text" name="titulo" id="titulo" placeholder="Escreva o título"  value={this.state.titulo} onChange={this.onChange}/>
              </FormGroup>
              <FormGroup>
                <Label for="descricao">Descrição</Label>
                <Input type="textarea" name="descricao" id="descricao" placeholder="Escreva uma descrição"  value={this.state.descricao} onChange={this.onChange}/>
              </FormGroup>
              <FormGroup>
                <Label for="sinopse">Sinopse</Label>
                <Input type="textarea" name="sinopse" id="sinopse" placeholder="Escreva uma sinopse para o livro"  value={this.state.sinopse} onChange={this.onChange}/>
              </FormGroup>
              <Row form>
                <Col md={6}>
                  <FormGroup>
                    <Label for="paginas">Páginas do Livro</Label>
                    <Input type="number" name="paginas" id="paginas" placeholder="Quantidade de páginas do livro"  value={this.state.paginas} onChange={this.onChange}/>
                  </FormGroup>
                </Col>
                <Col md={6}>
                  <FormGroup>
                    <Label for="dataPublicacao">Data de Publicação</Label>
                    <Input type="date" name="dataPublicacao" id="dataPublicacao" placeholder="Escreva a data de publicação" value={this.state.dataPublicacao} onChange={this.onChange} />
                  </FormGroup>
                </Col>
              </Row>
              
              <FormGroup>
                <Label for="idAutor">Autor</Label>
                <Dropdown list={this.state.autores} name="idAutor" property="nome" onChange={this.onChange} message="Escolha o Autor:" valueProperty="idAutor" value={this.state.idAutor}/>
              </FormGroup>
              <Row form>
                <Col md={6}>
                  <FormGroup>
                    <Label for="idEditora">Editora</Label>
                    <Dropdown list={this.state.editoras} name="idEditora" property="nome" onChange={this.onChange} message="Escolha a Editora:" valueProperty="idEditora" value={this.state.idEditora}/>
                  </FormGroup>
                </Col>
                <Col md={6}>
                  <FormGroup>
                    <Label for="idGenero">Gênero</Label>
                    <Dropdown list={this.state.generos} name="idGenero" property="descricao" onChange={this.onChange} message="Escolha um Gênero:" valueProperty="idGenero" value={this.state.idGenero}/>
                  </FormGroup>
                </Col>
              </Row>
              <FormGroup>
                <Label for="link">Link para comprar</Label>
                <Input type="text" name="link" id="link" placeholder="Escreva o link de venda" value={this.state.link} onChange={this.onChange}/>
              </FormGroup>
            </Form>
          </ModalBody>
          <ModalFooter>
            <Button color="success" outline onClick={this.salvar}>Salvar</Button>{' '}
            <Button color="secondary" outline onClick={this.cancelar}>Cancel</Button>
          </ModalFooter>
        </Modal>

      </div>
    );
  }
}

function Dropdown({list, name, property, onChange, message, valueProperty, value}) {
  return (
    <Input type="select" name={name} id={name} onChange={onChange} value={value}>
      <option>{message}</option>
      {(list || []).map((x, i) => (<option key={i} value={x[valueProperty]}>{x[property]}</option>))}
    </Input>
  )
}

function formatarData(stringData) {
  const data = moment(stringData)
  return data.toJSON();
}
