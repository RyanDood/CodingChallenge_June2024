import { useDispatch, useSelector } from "react-redux";
import { updateAccountID } from "../../../accountSlice";
import axios from "axios";

function UserEvent(props) {

    const date = new Date(props.beneficiary.event.date);
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Adding 1 because months are zero-indexed
    const day = date.getDate().toString().padStart(2, '0');
    const formattedDate = year + "-" + month + "-" + day;
    props.beneficiary.event.date = formattedDate;

    return (
        <div className="whiteOutlineBox75">
            <div className="whiteOutlineBoxMargin">
                <span className="clickRegisterText">Title: {props.beneficiary.event.title}</span>
                <div className="smallBox23">
                <span className="clickRegisterText">Description: {props.beneficiary.event.description}</span>
                </div>
                <span className="clickRegisterText">Date: {props.beneficiary.event.date}</span>
                <span className="clickRegisterText">Location: {props.beneficiary.event.location}</span>
                <span className="clickRegisterText">MaxAttendees: {props.beneficiary.event.maxAttendees}</span>
                <span className="clickRegisterText">Fee: {props.beneficiary.event.registrationFee}</span>
            </div>
        </div>
    );
}

export default UserEvent;