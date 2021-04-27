import React,{useState} from 'react';
import {useHistory,Link} from "react-router-dom";
import "../style/header.css";
import logo from "../images/logo.png"
export default function Header({isLoginPage}) {
    const [navClass,setNavClass]=useState("fas fa-bars")
    const [navId,setNavId]=useState("nav-hidden")
    const history= useHistory();
    const toggleNav= (e)=>{
        if(e.target.className==="fas fa-bars"){
            setNavClass("fas fa-times-circle");
            setNavId("nav-shown");
        }
        else{
            setNavClass("fas fa-bars");
            setNavId("nav-hidden");
        }
    }

    const logOut= (e)=>{
        e.preventDefault();
        localStorage.removeItem("token");
        localStorage.removeItem("returnUrl")
        history.push("/")
        return;
    }
    return (
        <header id="top">
            <div id="mobile-nav">
                <figure className="logo-container">
                   <a href="" id="logo"><img src="" alt="Company logo "/></a>
                </figure>
                <i id="nav-toggle" className={navClass} onClick={toggleNav}></i>
            </div>
            <nav id={navId}>
                <a href="" className="nav-link">About Us</a>
                <a href="" className="nav-link">Services</a>
                <Link className="nav-link" to="/careers">Careers</Link>
                
                    <a href="" className="{isLoginPage?}"  hidden={isLoginPage?true:false}onClick={logOut} >Log Out</a>

                
                
            </nav>
        </header>

    )
}
