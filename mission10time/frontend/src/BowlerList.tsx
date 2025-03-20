import { useEffect, useState } from "react";
import {bowler} from "./types/bowler"

function BowlerList () {

    const [bowlers, setBowlers] = useState<bowler[]>([])

    useEffect(() => {
        const fetchBowler = async () => {
            const response = await fetch ('https://localhost:5000/api/Bowler');
            const data = await response.json();
            setBowlers(data);
        };
        fetchBowler();
    }, []);
    

    

    return (
        <>
            <h2>Bowlers:</h2>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Team</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Zipcode</th>
                        <th>Phone Number</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        bowlers.map((f) => (
                            <tr key={f.bowlerID}>
                                <td>
                                    {`${f.bowlerFirstName} ${f.bowlerMiddleInit ? f.bowlerMiddleInit + '.' : ''} ${f.bowlerLastName}`}
                                </td>

                                <td>{f.teamID === 1 ? "Marlins" : f.teamID === 2 ? "Sharks" : f.teamID}</td>
                                <td>{f.bowlerAddress}</td>
                                <td>{f.bowlerCity}</td>
                                <td>{f.bowlerState}</td>
                                <td>{f.bowlerZip}</td>
                                <td>{f.bowlerPhoneNumber}</td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        </>
    );
}

export default BowlerList;