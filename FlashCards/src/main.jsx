import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import './index.css'

import Card from './card';
import Flash from './flash';
import FlashCard from './flashcard';
import Quiz from './quiz';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Card/>,
  },
  {
    path: "/flash",
    element : <Flash/>,
  },
  {
    path: "/flashcard",
    element : <FlashCard/>,
  },
  {
    path: "/quiz/:id",
    element : <Quiz/>,
  }
]);

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
