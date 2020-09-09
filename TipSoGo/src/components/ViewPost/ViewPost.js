import React, { useState, useEffect } from 'react';
import Axios from 'axios'

function ViewPost({match}) {
    const [data, setData] = useState([]);

    useEffect(() => {
        async function getPost() {
            const data = await Axios.get('/API/BulletinBoard/GetAllBulletin');
            const list = data.data.bulletins;
            const index = match.params.id;
            const newList = list.filter(function(element) {
                return element.BulletinIdx == index;
            });
            setData(newList[0]);
        }
        getPost();
    }, []);

    return (
        <div className="ViewPost">
            <div className="ViewPost-Container">
                <img src=""></img>
                <h1>{data.Title}</h1>
                <div className="ViewPost-details">
                    <span>
                        {data.UserName}&nbsp;&nbsp;
                        </span>
                    <span>
                        {data.CreatedDate}
                        </span>
                    <div className="ViewPost-Contents">
                        {data.Contents}
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ViewPost;