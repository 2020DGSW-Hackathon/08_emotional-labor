import React, { useEffect, useState } from 'react';
import ListCard from 'D:/Coding/React/tipsogo/src/components/List/ListCard';
import './Account.css';
import Axios from 'axios';
import cookie from 'react-cookies'

function Account({match}) {
    const [data, setData] = useState([]);

    useEffect(() => {
        async function getData() {
            const data = await Axios.get('/API/BulletinBoard/GetAllBulletin');
            const list = data.data.bulletins;
        
            const newList = list.filter(function(element) {
                return element.UserName === match.params.name;
            });
            console.log(newList);
            setData(newList.map((data, index) => {
                return <ListCard key={index} data={data} />
            }));
        }
        getData();
    },[])

    return(
        <div>
            <div className="Account">
            <div className="AccountList_Container">
                <table className="AccountList_View">
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
        </div>
    );
}

export default Account;