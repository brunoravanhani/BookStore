import React, { Component } from 'react';
import * as Api from '../../services/autorApi';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input } from 'reactstrap';

export class Autor extends Component {

  state = {
    autores: [],
    autorEscolhido: null,
    autorNome: '',
    autorId: null,
    modal: false
  }

  componentDidMount() {
    this.fetchAutores();
  }

  fetchAutores = async () => {
    const autores = await Api.buscar();
    this.setState({autores});
  }

  onChange = (e) => {
    const {name, value} = e.target;
    const newState = {};
    newState[name] = value;
    this.setState({...newState});
  }

  
  salvarAutor = async () => {
    const {autorNome, autorId} = this.state;
    if (autorNome && autorNome !== '') {
      if (!autorId) {
        await Api.novo({
          nome: autorNome
        });
      } else {
        await Api.atualizar({
          idAutor: autorId,
          nome: autorNome
        });
      }
      this.fetchAutores();
      this.toggleModal();
    }
  }

  excluirAutor = async (id) => {
    await Api.excluir(id);
    this.fetchAutores();
  }
  
  novoAutor = () => {
    this.setState({
      autorEscolhido: null,
      autorNome: '',
      autorId: null,
    });
    this.toggleModal();
  }

  editarAutor = (id) => {
    const autor = this.state.autores.find(x => x.idAutor === id);
    this.setState({ autorEscolhido: autor, autorNome: autor.nome, autorId: autor.idAutor });
    this.toggleModal();
  }
  cancelar = () => {
    this.setState( {
      autorEscolhido: null,
      autorNome: '',
      autorId: null,
    });
    this.toggleModal();
  }

  toggleModal = () => {
    this.setState(prevState => ({
      modal: !prevState.modal
    }));
  }

  renderAutor = (autor, index) => {
    return (
      <tr key={index}>
        <td style={{width: '80%'}}>
          {autor.nome}
        </td>
        <td>
          <Button outline color="primary" onClick={() => this.editarAutor(autor.idAutor)}>Editar</Button>{' '}
          <Button outline color="danger" onClick={() => this.excluirAutor(autor.idAutor)}>Excluir</Button>
        </td>
      </tr>
    );
  }

  render () {
    return (
      <div>
        <h1>Autores Cadastrados</h1>
        
        <div style={{marginBottom: 10}}>
          <Button color="primary" onClick={this.novoAutor}>Cadastrar Novo</Button>
        </div>

        <table className='table table-striped'>
          <thead>
            <tr>
              <th>Nome do Autor</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {(this.state.autores || []).map(this.renderAutor)}
          </tbody>
        </table>

        <Modal isOpen={this.state.modal} toggleModal={this.cancelar} >
          <ModalHeader toggleModal={this.cancelar}>Autor</ModalHeader>
          <ModalBody>
            <Form>
              <FormGroup>
              <Label for="autorNome">Nome do Autor</Label>
              <Input type="text" name="autorNome" id="autorNome" placeholder="Escreva o nome do Autor"  value={this.state.autorNome} onChange={this.onChange}/>
            </FormGroup>
            </Form>
          </ModalBody>
          <ModalFooter>
            <Button color="success" outline onClick={this.salvarAutor}>Salvar</Button>{' '}
            <Button color="secondary" outline onClick={this.cancelar}>Cancel</Button>
          </ModalFooter>
        </Modal>

      </div>
    );
  }
}
