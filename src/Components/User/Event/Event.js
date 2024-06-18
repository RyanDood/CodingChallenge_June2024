import { useDispatch, useSelector } from "react-redux";
import { updateAccountID } from "../../../accountSlice";
import axios from "axios";

function Event(props) {

    var dispatch = useDispatch();
    

    function updateAccountId() {
        dispatch(
            updateAccountID(props.beneficiary.eventID)
        );
        ask(props.beneficiary.eventID);
    }

    
    function ask(data){
        var userID = sessionStorage.getItem('memberID');
        console.log(userID)
        console.log(data)
        var newUser = {
            "userID": userID,
            "eventID": data
          }
        if(window.confirm("Are you sure you want to register")){
            registerUser(newUser);
        }
    }

    async function registerUser(newUser){
        await axios.post('https://localhost:7147/api/Registration/EventRegister',newUser).then(function (response) {
                console.log(response.data);
            })
            .catch(function (error) {
                alert(error.response.data);
            })
    }


    const date = new Date(props.beneficiary.date);
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Adding 1 because months are zero-indexed
    const day = date.getDate().toString().padStart(2, '0');
    const formattedDate = year + "-" + month + "-" + day;
    props.beneficiary.date = formattedDate;

    return (
        <div className="whiteOutlineBox75">
            <div className="whiteOutlineBoxMargin">
                <span className="clickRegisterText">Title: {props.beneficiary.title}</span>
                <div className="smallBox23">
                <span className="clickRegisterText">Description: {props.beneficiary.description}</span>
                    <span className="pointer" onClick={updateAccountId}>
                        <div className="nav-link textDecoGreen">Register</div>
                    </span>
                </div>
                <span className="clickRegisterText">Date: {props.beneficiary.date}</span>
                <span className="clickRegisterText">Location: {props.beneficiary.location}</span>
                <span className="clickRegisterText">MaxAttendees: {props.beneficiary.maxAttendees}</span>
                <span className="clickRegisterText">Fee: {props.beneficiary.registrationFee}</span>
            </div>
        </div>
    );
}

export default Event;