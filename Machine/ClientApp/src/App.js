import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { FetchData } from './components/FetchData';
import { Home } from './components/Home';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={FetchData} />
        <Route path='/adminpannelonlyforyou' component={Home} />
      </Layout>
    );
  }
}
