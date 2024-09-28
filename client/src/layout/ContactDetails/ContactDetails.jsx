import React,{useState, useEffect} from "react";
import { useNavigate,useParams } from "react-router-dom";
import axios from "axios";

const baseApiUrl = process.env.REACT_APP_API_URL;

const ContactDetails = (props) => {
    const [contact,setContact] = useState({name:"", email:""});
    const {id} = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const url = `${baseApiUrl}/contact/${id}`;
        axios.get(url).then(
            response => {
                setContact(response.data);
            }
        ).catch(
            err => {
                console.log(err);
                navigate("/");
            }
        )
    },[id,navigate]);

    const handleRemove = () => {
        const url = `${baseApiUrl}/contacts/${id}`; 
        if(window.confirm("Are you sure?")){
            axios.delete(url).then(navigate("/"))
            .catch(
                console.log("Error")
            );
        }
    }

    const handleUpdate = () => {
        const url = `${baseApiUrl}/contacts/${id}`;
        axios.put(url, contact)
        .then(navigate("/"))
        .catch(console.log("Error"))
   
    }


    return (
        <div className="container mt-5">
            <h2>Contact details</h2>
            <div className="mb-3">
                <label className="form-label">Name:</label>
                <input className="form-control"
                    type="text"
                    value={contact.name} 
                    onChange={(e) => {setContact({...contact,name: e.target.value});}}
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Email:</label>
                <input 
                className="form-control"
                type="email"
                value={contact.email} 
                onChange={(e) => {setContact({...contact,email: e.target.value}); }}
                />
            </div>
            <div>
                <button
                    className="btn btn-primary me-2" onClick={(e) => {handleUpdate()}}>
                    Update
                </button>
                <button
                    className="btn btn-danger me-2" onClick={(e) => {handleRemove()}}>
                    Delete
                </button>
                <button
                    className="btn btn-secondary me-2" onClick={(e) => {navigate("/")}}>
                    Return to list
                </button>
            </div>
        </div>
    )

}
export default ContactDetails;