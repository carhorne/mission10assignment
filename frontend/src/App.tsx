import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Header from './components/Header';
import BowlerTable from './components/BowlerTable';
import { Bowler } from './types/Bowler';
import './App.css';

const App: React.FC = () => {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        setLoading(true);
        const response = await axios.get<Bowler[]>('/api/Bowlers');
        setBowlers(response.data);
        setError(null);
      } catch (err) {
        setError('Error fetching bowler data. Please try again later.');
        console.error('Error fetching data:', err);
      } finally {
        setLoading(false);
      }
    };

    fetchBowlers();
  }, []);

  return (
    <div className="App">
      <Header />
      {error && <div className="error-message">{error}</div>}
      <BowlerTable bowlers={bowlers} loading={loading} />
    </div>
  );
};

export default App;
