import { Team } from './Team';

/**
 * Interface representing a bowler entity
 */
export interface Bowler {
  bowlerID: number;
  bowlerFirstName: string;
  bowlerMiddleInit: string | null;
  bowlerLastName: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
  teamID: number;
  team: Team;
}
