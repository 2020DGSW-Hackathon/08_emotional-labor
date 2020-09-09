import React from 'react'
import { Link } from 'react-router-dom'
import './ListCard.css';
function ListCard(props) {

    return (
        <tr>
            <td className="title"><Link to={'/post/' + props.data.BulletinIdx}>{props.data.Title}</Link>[{props.data.NumComments}]</td>
            <td className="name">{props.data.UserName}</td>
            <td className="date">{props.data.CreatedDate}</td>
        </tr>
    );
}

export default ListCard;