import React, { Component } from 'react';
import * as Api from '../../services/livroApi';
import { Button } from 'reactstrap';

export class Livro extends Component {

  state = {
    livros: []
  }

  async componentDidMount() {
    const livros = await Api.buscar();
    this.setState({livros});
  }

  renderLivro(livro) {
    return (
      <tr>
        <td style={{width: '80%'}}>
          {livro.titulo}
        </td>
        <td>
          <Button outline color="primary">Editar</Button>{' '}
          <Button outline color="danger">Excluir</Button>
        </td>
      </tr>
    );
  }

  render () {
    return (
      <div>
        <h1>Livros Cadastrados</h1>
        
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

      </div>
    );
  }
}
