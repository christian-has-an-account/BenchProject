export class Team {
  teamID: number;
  teamName: string;
  client: Client;
}

export interface Client {
  clientID: number;
  clientName: string;
}
