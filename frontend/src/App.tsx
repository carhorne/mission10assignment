import React, { useState, useEffect } from 'react';
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
        // Replace with your actual API URL
        const response = await fetch('https://localhost:7247/api/Bowlers');
        
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        
        const data = await response.json();
        setBowlers(data);
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