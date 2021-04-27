import React from 'react';
import {BrowserRouter as Router,Route,Switch,Redirect} from "react-router-dom";
import DetailsPage from "./pages/detailsPage";
import Homepage from "./pages/homepage";


function checkAuthenticationStatus(returnUrl){
  let token= localStorage.getItem("token");
  return token;
}
const ProtectedRoute = ({ component: Component, path:returnUrl,...rest }) => {
  console.log(returnUrl)
  let hasRouteAccess= checkAuthenticationStatus(returnUrl);
  if(hasRouteAccess) return (<Route {...rest} path={returnUrl} render={props => 
    <Component {...rest} {...props} />} />)
  
  localStorage.setItem("returnUrl",returnUrl)
  let url ="/?returnUrl=" + returnUrl;
  return <Redirect to={url}></Redirect>
  
}

function App() {
  return (
    <Router>
      <Switch>
        {/* UnProtected routes list */}
        <Route exact path="/" component={Homepage}></Route>
        
        {/* Protected routes list */}
      <ProtectedRoute exact path="/details" component={DetailsPage}></ProtectedRoute>
      </Switch>

    </Router>

  );
}

export default App;