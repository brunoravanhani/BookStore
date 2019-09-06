import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Bem-vindo ao BookStore</h1>
        <p>
          <a href="/livro">Cadastrar/Buscar Livros</a>
        </p>
        <p>
          <a href="/autor">Cadastrar/Buscar Autores</a>
        </p>
      </div>
    );
  }
}
