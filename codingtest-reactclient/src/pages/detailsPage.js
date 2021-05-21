import React,{useEffect,useCallback,useState} from 'react';
import {useHistory} from "react-router-dom";
import  Header from "../components/header";
import Footer from "../components/footer";
import { getDetails,tryRefreshToken } from '../apis/user';
import Spinner from "../components/spinner"

export default function DetailsPage () {
    const [details,setDetails]=useState([]);
    const history=useHistory();
    const callback=useCallback( async ()=>{
        let resp=await getDetails();
        if(resp.status===200) setDetails(resp.data);
        else if(resp.status===401){
            resp=await tryRefreshToken();
            if(resp == 200) history.push("/details");
            else{
                history.push("/");
                 localStorage.setItem("returnUrl","/details")
            }
           
            
            return;
        }
    })
    useEffect(()=>{
        callback();
    },[])
    return (
        <div>
            <Header></Header>
                <div className="page-body">
                    <div className="p-top details-page">
                        <h2 >Users Details</h2>
                        {
                            details.length===0 ? <Spinner></Spinner> :
                            <div className="details-page">
                                <table className="table table-striped">
                                    <thead className="thead-dark">
                                        <tr>
                                            <th scope="col">S/N</th>
                                            <th scope="col">Name</th>
                                            <th scope="col">Email</th>
                                            <th scope="col">Registration Date</th>
                                        </tr>
                                        
                                    </thead>
                                    <tbody>
                                        {
                                            details.map((x,index) => {
                                                return (
                                                    <tr key={index}>
                                                        <td scope="row">{index}</td>
                                                        <td>{x.name}</td>
                                                        <td>{x.email}</td>
                                                        <td>{x.registrationDate}</td>
                                                    </tr>
                                                )
                                            })
                                        }
                                    </tbody>
                                </table>
                            </div>
                            
                        }
                        
                    </div>
                    
                </div>
            <Footer></Footer>
        </div>
    )
}
