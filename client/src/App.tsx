import React from 'react'
import { Switch, Route, BrowserRouter as Router } from 'react-router-dom'

import 'antd/dist/antd.css'

import Login from './component/Auth/login'
import Register from './component/Auth/register'
import Menu from './component/Menu'
import Homes from './component/Homes'
import Staff from './component/Staff'
import Proposal from './component/Proposal'
import Polling from './component/Polling'
import Meetings from './component/Meetings'

const LoginComponent = () => <Login />
const RegisterComponent = () => <Register />
const HomesComponent = () => <Homes />
const StaffComponent = () => <Staff />
const ProposalComponent = () => <Proposal />
const PollingComponent = () => <Polling />
const MeetingsComponent = () => <Meetings />

const App = () => {
  return (
    <>
      <Router>
        <Menu />
        <div className="container">
          <Switch>
            <Route exact path="/" render={LoginComponent} />
            <Route exact path="/login" render={LoginComponent} />
            <Route exact path="/register" render={RegisterComponent} />
            <Route exact path="/homes" render={HomesComponent} />
            <Route exact path="/staff" render={StaffComponent} />
            <Route exact path="/proposal" render={ProposalComponent} />
            <Route exact path="/polling" render={PollingComponent} />
            <Route exact path="/meetings" render={MeetingsComponent} />
          </Switch>
        </div>
      </Router>
    </>
  )
}

export default App
