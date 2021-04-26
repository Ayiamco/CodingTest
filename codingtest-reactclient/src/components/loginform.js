import React,{useState} from 'react';
import loginUser from "../apis/user";

export default function Loginform() {
    const [formData,setFormData]= useState({
        email:"",
        password:""
    })

    const handleInput= (e)=>{
        setFormData(prev=> (
            {...prev,[e.target.name]:e.target.value}
        ))
    }     
    const handleForm = async (e)=>{
        e.preventDefault();
        let resp= await loginUser(formData);
        console.log(resp)
    }
    return (
        <div>
            <form onSubmit={handleForm}>
                <input type="email" required name="email" placeholder="Enter your Email" value={formData.email} onChange={handleInput}></input>
                <input name="password"  placeholder="Enter your password" value ={formData.password} onChange={handleInput}></input>
                <button type="submit">Login</button>
            </form>
        </div>
    )
}
