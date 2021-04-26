import React from 'react'

export default function top() {
    return (
        <header id="top">
            <div id="mobile-nav">
                <figure class="logo-container">
                   <a href="" id="logo"><img src="~/Content/images/logo.png" alt=""/></a>
                </figure>
                <i id="show-nav" class="fas fa-bars  "></i>
                <i id="hide-nav" class="fas fa-times-circle  "></i>
            </div>
            <nav>
                <a href="" class="nav-link">About Us</a>
                <a href="" class="nav-link">Services</a>
                <a href="" class="nav-link">Our Approach</a>
                <a href="" class="nav-link">Contact Us</a>
                
            </nav>
        </header>

    )
}
