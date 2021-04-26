import React from 'react';
import {BrowserRouter as Router,Route,Switch,Redirect} from "react-router-dom";

import Homepage from "./pages/homepage";

function checkAuthenticationStatus(returnUrl){
  let token= localStorage.getItem("token");
  return token ;
}
const ProtectedRoute = ({ component: Component, path:returnUrl,...rest }) => {
  let hasRouteAccess= checkAuthenticationStatus(returnUrl);
  if(hasRouteAccess) return (<Route {...rest} path={returnUrl} render={props => 
    <Component {...rest} {...props} />} />)
  
  localStorage.setItem("returnUrl",returnUrl)
  return <Redirect to="/"></Redirect>
  
}

function App() {
  return (
    <Router>
      <Switch>
        {/* UnProtected routes list */}
        <Route exact path="/" component={Homepage}></Route>
        
        {/* Protected routes list */}
      </Switch>

    </Router>

  );
}

export default App;