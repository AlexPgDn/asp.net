import React,{useState} from "react";

const FormContact = (props) => {
        
        const [contactName,setContactName] = useState("");
        const [contactEmail,setContactEmail] = useState("");

        const submit = () => {
                if (contactName === "" || contactEmail === "") return;
                props.addContact(contactName,contactEmail)
                setContactEmail("");
                setContactName("");
        }
        
        return (
        <div>
            <div className="mb-3">
                <form>
                <div class="form-floating mb-3">
                    <input type="text" class="form-control" id="floatingInput" placeholder="name@example.com"
                    value={contactName}
                    onChange={(e) => {setContactName(e.target.value)}}
                    />
                    <label for="floatingInput">Put your contact name</label>
                </div>
                <div class="form-floating mb-3">
                    <input type="text" class="form-control" id="floatingInput" placeholder="name@example.com"
                    value={contactEmail}
                    onChange={(e) => {setContactEmail(e.target.value)}}
                    />
                    <label>Put your contact mail</label>
                </div>

                </form>

            </div>
            <div>
                <button className="btn btn-outline-primary"
                    onClick={() => {submit()}}>
                    Add contact
                </button>
            </div>


        </div>
        );
}
export default FormContact;