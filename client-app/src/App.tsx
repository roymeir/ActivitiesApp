import React, { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').
      then(response => {
        setActivities(response.data)
      })
  }, [])

  return (
    <div className='App'>
      <h1>HI</h1>
      <ul>
        {activities.map(activity => (
          <li key={activity.id}>
            {activity.title}
          </li>
        )
        )}
      </ul>
    </div>
  )
}

export default App
