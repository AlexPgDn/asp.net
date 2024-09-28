import React from "react";
import { Link } from "react-router-dom";

const RowTableContact = (props) => {

    return (
        <tr onClick={() => {}}>
                <th>{props.Id}</th>
                <th>{props.Name}</th>
                <th>{props.Email}</th>
                <th>
                    <Link 
                    to={`/contact/${props.Id}`}
                    className="btn btn-primary btn-sm"
                    >
                    Info
                    </Link>
                </th>
              </tr>

    )
}
export default RowTableContact;