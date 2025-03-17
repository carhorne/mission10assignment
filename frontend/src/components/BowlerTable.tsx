import React from 'react';
import { Bowler } from '../types/Bowler';
import './BowlerTable.css';

interface BowlerTableProps {
  bowlers: Bowler[];
  loading: boolean;
}

const BowlerTable: React.FC<BowlerTableProps> = ({ bowlers, loading }) => {
  if (loading) {
    return <div className="loading">Loading bowler data...</div>;
  }

  return (
    <div className="table-container">
      <table className="bowler-table">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.length === 0 ? (
            <tr>
              <td colSpan={7} className="no-data">No bowlers found</td>
            </tr>
          ) : (
            bowlers.map((bowler) => (
              <tr key={bowler.bowlerID}>
                <td>
                  {bowler.bowlerFirstName}{' '}
                  {bowler.bowlerMiddleInit ? bowler.bowlerMiddleInit + '. ' : ''}
                  {bowler.bowlerLastName}
                </td>
                <td>{bowler.team.teamName}</td>
                <td>{bowler.bowlerAddress}</td>
                <td>{bowler.bowlerCity}</td>
                <td>{bowler.bowlerState}</td>
                <td>{bowler.bowlerZip}</td>
                <td>{bowler.bowlerPhoneNumber}</td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
};

export default BowlerTable;
