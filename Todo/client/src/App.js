import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import "bootstrap/dist/css/bootstrap.min.css";
import Todo from "./Todo";
import { Route, BrowserRouter } from "react-router-dom";


class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <div className="App">
          <Route path="/todo" component={Todo}/>
        </div>
      </BrowserRouter>
    );
  }
}

export default App;
