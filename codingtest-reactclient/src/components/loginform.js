import React,{useState} from 'react';
import useLoginForm from '../customhooks/useLoginForm';
import "../style/login.css";
import Spinner from './spinner';
export default function Loginform() {
    let {formData,handleInput,handleForm,errorMessage,isRequesting,IsNetworkError}=useLoginForm()
    return (
    <section  className="login-form-con">
        <h2 className="text-center p-top">Login</h2> 
        <p className="text-danger text-center">{IsNetworkError?"Error: check network connection":""}</p>
        <form role = "form" id="login-form" onSubmit={handleForm}>
            <div className="form-group w-100">
                <label htmlFor="email">Email:</label>
                <input  className="form-control" required name="email" 
                    placeholder="Enter your Email" value={formData.email} onChange={handleInput}></input>
                    <span className="text-danger">{errorMessage.email}</span>
            </div>
             <div className="form-group w-100">
                <label htmlFor="password">Password:</label>
                <input type="password"  className="form-control" required name="password" 
                    placeholder="Enter your password" value={formData.password} onChange={handleInput}></input>
                <span className="text-danger">{errorMessage.password}</span>
            </div>
             <div className="form-group w-100">
                <input type="submit" value="Log in" className="btn btn-primary" style={{disable:isRequesting}} />
            </div>
            <div className="form-group w-100" style={{display:isRequesting?"block":"none"}}>
                <Spinner></Spinner>
            </div>

        </form>
    </section> 
    )  
}
