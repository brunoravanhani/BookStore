import React, { Component } from 'react';
import * as Api from '../../services/editoraApi';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input } from 'reactstrap';

export class Editora extends Component {

  state = {
    editoras: [],
    editoraEscolhida: null,
    nomeEditora: '',
    idEditora: null,
    modal: false
  }

  componentDidMount() {
    this.fetchEditoras();
  }

  fetchEditoras = async () => {
    const editoras = await Api.buscar();
    this.setState({editoras});
  }

  onChange = (e) => {
    const {name, value} = e.target;
    const newState = {};
    newState[name] = value;
    this.setState({...newState});
  }

  
  salvar = async () => {
    const {nomeEditora, idEditora} = this.state;
    if (nomeEditora && nomeEditora !== '') {
      if (!idEditora) {
        await Api.novo({
          nome: nomeEditora
        });
      } else {
        await Api.atualizar({
          idEditora,
          nome: nomeEditora
        });
      }
      this.fetchEditoras();
      this.toggleModal();
    }
  }

  excluir = async (id) => {
    await Api.excluir(id);
    this.fetchEditoras();
  }
  
  abrirModalNovo = () => {
    this.setState({
      editoraEscolhida: null,
      nomeEditora: '',
      idEditora: null,
    });
    this.toggleModal();
  }

  abrirModelEdicao = (id) => {
    const editora = this.state.editoras.find(x => x.idEditora === id);
    this.setState({ editoraEscolhida: editora, nomeEditora: editora.descricao, idEditora: editora.idEditora });
    this.toggleModal();
  }
  cancelar = () => {
    this.setState( {
      editoraEscolhida: null,
      nomeEditora: '',
      idEditora: null,
    });
    this.toggleModal();
  }

  toggleModal = () => {
    this.setState(prevState => ({
      modal: !prevState.modal
    }));
  }

  renderLinha = (editora, index) => {
    return (
      <tr key={index}>
        <td style={{width: '80%'}}>
          {editora.nome}
        </td>
        <td>
          <Button outline color="primary" onClick={() => this.abrirModelEdicao(editora.idEditora)}>Editar</Button>{' '}
          <Button outline color="danger" onClick={() => this.excluir(editora.idEditora)}>Excluir</Button>
        </td>
      </tr>
    );
  }

  render () {
    return (
      <div>
        <h1>Editoras Cadastradas</h1>
        
        <div style={{marginBottom: 10}}>
          <Button color="primary" onClick={this.abrirModalNovo}>Cadastrar Nova</Button>
        </div>

        <table className='table table-striped'>
          <thead>
            <tr>
              <th>Nome da Editora</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {(this.state.editoras || []).map(this.renderLinha)}
          </tbody>
        </table>

        <Modal isOpen={this.state.modal} toggleModal={this.cancelar} >
          <ModalHeader toggleModal={this.cancelar}>Cadastrar Editora</ModalHeader>
          <ModalBody>
            <Form>
              <FormGroup>
              <Label for="nomeEditora">Nome da Editora</Label>
              <Input type="text" name="nomeEditora" id="nomeEditora" placeholder="Escreva o nome da editora"  value={this.state.nomeEditora} onChange={this.onChange}/>
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
