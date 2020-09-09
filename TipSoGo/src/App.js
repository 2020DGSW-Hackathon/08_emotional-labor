import React from 'react';
import { Header, Home, List, Write, ViewPost, Account } from './components';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'

function App() {
  return (
    <div className="App">
      <Header />
      <Router>
        <Route exact path='/' component={Home} />
        <Switch>          
          <Route path='/list/:topic' component={List} />
          <Route exact path='/write' component={Write} />
          <Route path='/post/:id' component={ViewPost} />
          <Route path='/account/:name' component={Account} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
