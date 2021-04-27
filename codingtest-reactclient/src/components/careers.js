import React from 'react';
import careerbanner from "../images/careerbanner.jpg"
import peopleGlassgow from "../images/people-Glasgow.jpg"
import "../style/careers.css"

export default function Career() {
    return (
        <div>
            <div className="banner-section">
                <img id="banner-img" src={careerbanner} alt="background image"/>
                <h1>See how far your thinking can go</h1>
            </div>
            <div className="mid-section">
                <div className="growth-card">
                    <h2>Endless growth opportunities</h2>
                    <p>
                        Our firms culture is rooted in our core
                        principles. Here, you will join diverse and
                        inclusive teams that support each other and
                        empower you to do your best work.
                    </p>
                </div>
                <img id="img-glasgow" src={peopleGlassgow} alt=""/>
            </div>
            <h2 className="jobs-header">Open Positions</h2>
            <div id="open-positions">
                <div id="mailing-list">
                    <h1>No Open Positions For now</h1>
                    <a href="">Join our mailing list</a>
                </div>
            </div>
        </div>
    )
}
