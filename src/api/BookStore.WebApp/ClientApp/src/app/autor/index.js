import React, { Component } from 'react';
import * as Api from '../../services/autorApi';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input } from 'reactstrap';

export class Autor extends Component {

  state = {
    autores: [],
    autorEscolhido: null,
    autorNome: '',
    modal: false
  }

  async componentDidMount() {
    const autores = await Api.buscar();
    this.setState({autores});
  }

  editarAutor = (id) => {
    const autor = this.state.autores.find(x => x.idAutor === id);
    this.setState({ autorEscolhido: autor, autorNome: autor.nome });
    this.toggle();
  }

  salvarAutor = () => {

  }

  cancelar = () => {
    this.setState( {
      autorEscolhido: null,
      autorNome: ''
    });
    this.toggle();
  }

  toggle = () => {
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
          <Button outline color="danger">Excluir</Button>
        </td>
      </tr>
    );
  }

  render () {
    return (
      <div>
        <h1>Autores Cadastrados</h1>
        
        <div style={{marginBottom: 10}}>
          <Button color="primary" onClick={this.toggle}>Cadastrar Novo</Button>
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

        <Modal isOpen={this.state.modal} toggle={this.cancelar} >
          <ModalHeader toggle={this.cancelar}>Autor</ModalHeader>
          <ModalBody>
            <Form>
              <FormGroup>
              <Label for="nomeAutor">Nome do Autor</Label>
              <Input type="text" name="autor" id="nomeAutor" placeholder="Escreva o nome do Autor"  value={this.state.autorNome}/>
            </FormGroup>
            </Form>
          </ModalBody>
          <ModalFooter>
            <Button color="success" outline onClick={this.toggle}>Do Something</Button>{' '}
            <Button color="secondary" outline onClick={this.cancelar}>Cancel</Button>
          </ModalFooter>
        </Modal>

      </div>
    );
  }
}
