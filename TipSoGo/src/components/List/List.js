import React, { useState, useEffect } from 'react';
import Axios from 'axios';
import ListCard from './ListCard';
import './List.css';
import { Link } from 'react-router-dom';
import edit from './edit.png'



function List ({match}) {
    const [data, setData] = useState([]);

    useEffect(() => {
        async function getData() {
            const data = await Axios.get('/API/BulletinBoard/GetAllBulletin');
            const list = data.data.bulletins;

            const newList = list.filter(function(element) {
                return element.Topic === match.params.topic;
            });

            setData(newList.map((data, index) => {
                return <ListCard key={index} data={data} />
            }));
        }
        getData();
    }, [])

    return (
        <div className="List">
            <div className="List_Container">
                <Link to="/write" style={{ textDecoration: 'none'}}>
                    <span>
                        <img src={edit}></img>
                        글쓰기
                    </span>
                </Link>
                <table className="List_View">
                    <thead>
                        <tr>
                            <th>제목</th>
                            <th>글쓴이</th>
                            <th>날짜</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data}
                    </tbody>
                </table>
            </div>
        </div>
    );

}

export default List;