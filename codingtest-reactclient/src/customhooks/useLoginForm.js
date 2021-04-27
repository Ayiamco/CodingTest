import {useState} from 'react';
import {useHistory} from "react-router-dom";
import {loginUser} from "../apis/user"

export default function useLoginForm() {
    const [formData,setFormData]= useState({
        email:"",
        password:""
    })
    const [errorMessage,setErrorMessage]=useState([])
    const [IsNetworkError,setIsNetworkError]= useState(false)
    const history= useHistory();
    const [isRequesting,setIsRequesting]=useState(false)

    const handleInput= (e)=>{
        setFormData(prev=> (
            {...prev,[e.target.name]:e.target.value}
        ))
    }     
    const handleForm = async (e)=>{
        e.preventDefault();
        setIsRequesting(true);
        let resp= await loginUser(formData);
        setIsRequesting(false);
        if(resp.status===200){
            localStorage.setItem("token",resp.data.token)
            localStorage.setItem('refreshToken',resp.data.token)
            if(localStorage.getItem("returnUrl")) history.push(localStorage.getItem("returnUrl"));
            else history.push("/details");
            return;
        }
        else if(resp.status===500) setIsNetworkError(true);
        else{
            setErrorMessage(JSON.parse(resp.message))
        }
    }
    return {formData,setFormData,handleForm,handleInput,errorMessage,isRequesting,IsNetworkError}
}
