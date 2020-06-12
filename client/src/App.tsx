import React from 'react';
import { Switch, Route, BrowserRouter as Router } from 'react-router-dom';

import Login from './component/Auth/login';
import Register from './component/Auth/register';

const LoginComponent = () => <Login />;
const RegisterComponent = () => <Register />

const App = () => {
  return (
    <Router>
      <Switch>
        <Route path="/"   render={LoginComponent} />
        <Route path="/login"   render={LoginComponent}/>
        <Route path="/register"  render={RegisterComponent}/>
      </Switch>
    </Router>
  );
}

export default App;
