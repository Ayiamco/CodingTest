import React from 'react'
import "../style/spinner.css"
export default function Spinner() {
    return (
        <div className="div-centered" style={{marginTop:"3em"}}>
            <div className="sk-chase" >
                <div className="sk-chase-dot"></div>
                <div className="sk-chase-dot"></div>
                <div className="sk-chase-dot"></div>
                <div className="sk-chase-dot"></div>
                <div className="sk-chase-dot"></div>
                <div className="sk-chase-dot"></div>
            </div>
        </div>
        
    )
}
