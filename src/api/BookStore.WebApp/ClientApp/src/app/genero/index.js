import React, { Component } from 'react';
import * as Api from '../../services/generoApi';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input } from 'reactstrap';

export class Genero extends Component {

  state = {
    generos: [],
    generoEscolhido: null,
    nomeGenero: '',
    idGenero: null,
    modal: false
  }

  componentDidMount() {
    this.fetchGeneros();
  }

  fetchGeneros = async () => {
    const generos = await Api.buscar();
    this.setState({generos});
  }

  onChange = (e) => {
    const {name, value} = e.target;
    const newState = {};
    newState[name] = value;
    this.setState({...newState});
  }

  
  salvar = async () => {
    const {nomeGenero, idGenero} = this.state;
    if (nomeGenero && nomeGenero !== '') {
      if (!idGenero) {
        await Api.novo({
          descricao: nomeGenero
        });
      } else {
        await Api.atualizar({
          idGenero,
          descricao: nomeGenero
        });
      }
      this.fetchGeneros();
      this.toggleModal();
    }
  }

  excluir = async (id) => {
    await Api.excluir(id);
    this.fetchGeneros();
  }
  
  abrirModalNovo = () => {
    this.setState({
      generoEscolhido: null,
      nomeGenero: '',
      idGenero: null,
    });
    this.toggleModal();
  }

  abrirModelEdicao = (id) => {
    const genero = this.state.generos.find(x => x.idGenero === id);
    this.setState({ generoEscolhido: genero, nomeGenero: genero.descricao, idGenero: genero.idGenero });
    this.toggleModal();
  }
  cancelar = () => {
    this.setState( {
      generoEscolhido: null,
      nomeGenero: '',
      idGenero: null,
    });
    this.toggleModal();
  }

  toggleModal = () => {
    this.setState(prevState => ({
      modal: !prevState.modal
    }));
  }

  renderLinha = (genero, index) => {
    return (
      <tr key={index}>
        <td style={{width: '80%'}}>
          {genero.descricao}
        </td>
        <td>
          <Button outline color="primary" onClick={() => this.abrirModelEdicao(genero.idGenero)}>Editar</Button>{' '}
          <Button outline color="danger" onClick={() => this.excluir(genero.idGenero)}>Excluir</Button>
        </td>
      </tr>
    );
  }

  render () {
    return (
      <div>
        <h1>Gêneros Cadastrados</h1>
        
        <div style={{marginBottom: 10}}>
          <Button color="primary" onClick={this.abrirModalNovo}>Cadastrar Novo</Button>
        </div>

        <table className='table table-striped'>
          <thead>
            <tr>
              <th>Gênero</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {(this.state.generos || []).map(this.renderLinha)}
          </tbody>
        </table>

        <Modal isOpen={this.state.modal} toggleModal={this.cancelar} >
          <ModalHeader toggleModal={this.cancelar}>Cadastrar Gênero</ModalHeader>
          <ModalBody>
            <Form>
              <FormGroup>
              <Label for="nomeGenero">Gênero</Label>
              <Input type="text" name="nomeGenero" id="nomeGenero" placeholder="Escreva a descrição do Genero"  value={this.state.nomeGenero} onChange={this.onChange}/>
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
