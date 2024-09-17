import React from "react";

const RowTableContact = (props) => {

    return (
        <tr onClick={() => {props.deleteContact(props.Id)}}>
                <th>{props.Id}</th>
                <th>{props.Name}</th>
                <th>{props.Email}</th>
              </tr>

    )
}
export default RowTableContact;