import React from 'react';
import './Home.css';

import book from './images/book.png';
import electronics from './images/wifi.png';
import people from './images/people.png';
import bed from './images/bed.png';

import { Link } from 'react-router-dom';

const Home = () => {
    return (
        <div className="Home">
            <h1>
                무엇을 도와드릴까요?
            </h1>
            <ul>
                <li id="link_school" className="link_list">
                    <Link to='/list/1' style={{ textDecoration: 'none', color: 'white' }}>
                    <div>
                        <img src={book}></img>
                        <p className="link_title">#학교</p>
                        시설물 / 공부방법
                    </div>
                    </Link>
                </li>
                <li id="link_electronics" className="link_list">
                    <Link to={'/list/2'} style={{ textDecoration: 'none', color: 'white' }}>
                    <div>
                        <img src={electronics}></img>
                        <p className="link_title">#전자기기</p>
                        노트북 / 휴대폰 사용
                    </div>
                    </Link>
                </li>
                <li id="link_jobsearch" className="link_list">
                    <Link to={'/list/3'} style={{ textDecoration: 'none', color: 'white' }}>
                        <div>
                            <img src={people}></img>
                            <p className="link_title">#구인구직</p>
                            대회 팀을 찾습니다
                        </div>
                    </Link>
                </li>
                <li id="dormitory" className="link_list">
                    <Link to={'/list/4'} style={{ textDecoration: 'none', color: 'white' }}> 
                    <img src={bed}></img>
                    <p className="link_title">#기숙사</p>
                    dragonRoad
                    </Link>
                </li>
            </ul>
        
        </div>
    );

}

export default Home;