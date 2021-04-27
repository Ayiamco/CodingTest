import React from 'react'
import Footer from '../components/footer';
import Header from '../components/header';
import Loginform from "../components/loginform";

export default function Homepage() {
    return (
        <div>
            <Header isLoginPage={true}></Header>
            <div className="page-body">
                <Loginform></Loginform>
            </div>
            <Footer></Footer>
        </div>
    )
}
