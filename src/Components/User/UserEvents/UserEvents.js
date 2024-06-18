import axios from 'axios';
import { useEffect, useState } from 'react';
import "../../../../src/Components/style.css"
import { Link, useNavigate } from 'react-router-dom';
import Event from '../Event/Event';
import UserEvent from '../EventU/UserEvent';
import { useSelector } from 'react-redux';

function UserEvents(){

    var [error,setError]= useState(false);
    var [errorMessage,setErrorMessage]= useState("");
    var [beneficiaries,setBeneficiaries] = useState([]);

    useEffect(() => {
        var userID = sessionStorage.getItem('memberID');
        allBeneficiaries(userID);
    },[])

   

    async function allBeneficiaries(userID){
        await axios.get('https://localhost:7147/api/Registration/GetAllEventsFromUsers?userID=' + userID).then(function (response) {
            setBeneficiaries(response.data);
            setError(false);
        })
        .catch(function (error) {
            console.log(error);
            setError(true);
            setErrorMessage(error.response.data);
        })  
    }

    return (
        <div className="smallBox17 col-md-12">
                <div className="smallBox21">
                    <ul className="smallBox22 nav">
                    <li className="nav-item highlight smallBox23">
                            <Link className="nav-link textDecoWhite smallBox23" to="/allevents">All Events</Link>
                        </li>
                        <li className="nav-item highlight smallBox23">
                            <Link className="nav-link textDecoGreen smallBox23" to="/userevents">Your Events</Link>
                        </li>
                        <li className="nav-item highlight smallBox23">
                            <Link className="nav-link textDecoWhite smallBox23" to="/">Signout</Link>
                        </li>
                    </ul>
                    {error ? 
                    <div className="smallBox48">
                        <div className="errorImage2 change-my-color2"></div>
                        <div className="clickRegisterText">{errorMessage}</div>
                    </div> :
                    <div className="scrolling">
                        {beneficiaries.map(beneficiary =>
                        <UserEvent key = {beneficiary.registrationID} beneficiary = {beneficiary}/>
                        )}
                    </div>}
                </div>
        </div>
    )
}

export default UserEvents;