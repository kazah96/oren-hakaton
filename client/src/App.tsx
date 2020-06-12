import React from 'react';
import { Switch, Route, BrowserRouter as Router } from 'react-router-dom';

import 'antd/dist/antd.css';

import Login from './component/Auth/login';
import Register from './component/Auth/register';
import Menu from './component/Menu'

const LoginComponent = () => <Login />;
const RegisterComponent = () => <Register />

const App = () => {
  return (
    <>
      <Menu />
      <Router>
        <Switch>
          <Route exact path="/"   render={LoginComponent} />
          <Route exact path="/login"   render={LoginComponent}/>
          <Route exact path="/register"  render={RegisterComponent}/>
        </Switch>
      </Router>
    </>
  );
}

export default App;
