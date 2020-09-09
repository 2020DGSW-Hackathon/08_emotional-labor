import React from 'react';
import { Link } from 'react-router-dom';
import './Header.css';

const Header = () => {
    return (
        <div className="Header">
            <span id="main_logo">
                TipSoGO
            </span>
            <span id="header_title">
                {}
            </span>
            <span id="myAccount">
                내 계정
            </span>
        </div>
    );
    
}

export default Header;