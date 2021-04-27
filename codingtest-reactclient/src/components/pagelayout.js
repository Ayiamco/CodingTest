import React from 'react'
import Header from "./header";
import Footer from "./footer";
export default function pagelayout({Pagebody}) {
    return (
        <div>
            <Header></Header>
            <div className="page-body">
                <Pagebody></Pagebody>
            </div>
            <Footer></Footer>
        </div>
    )
}
