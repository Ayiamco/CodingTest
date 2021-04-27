import React from 'react'
import facebook from "../images/facebook.svg"
import Instagram from "../images/Instagram.svg"
import LinkedIn from "../images/LinkedIn.svg"
import Twitter from "../images/Twitter.svg"
import "../style/footer.css";
export default function Footer() {
    return (
        <footer>
            <div className="ft-left">
                <a href="">Terms & Conditions</a>
                <a href="">Privacy policy</a>
            </div>
            <div className="ft-center"><p>&copy; Company Name 2021</p></div>
            <div className="ft-right">
                <a href=""><img src={facebook}/></a>
                <a href=""><img src={Instagram}/></a>
                <a href=""><img src={LinkedIn}/></a>
                <a href=""><img src={Twitter}/></a>
            </div>
        </footer>
    )
}
