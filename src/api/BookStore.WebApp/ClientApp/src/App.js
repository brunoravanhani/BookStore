import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Livro } from './app/livro';
import { Autor } from './app/autor';
import { Genero } from './app/genero';
import { Editora } from './app/editora';
// import { FetchData } from './components/FetchData';
// import { Counter } from './components/Counter';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/livro' component={Livro} />
        <Route path='/autor' component={Autor} />
        <Route path='/genero' component={Genero} />
        <Route path='/editora' component={Editora} />
      </Layout>
    );
  }
}
