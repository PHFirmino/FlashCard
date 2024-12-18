import { Link } from "react-router-dom"


export default function Navbar(){
    return (
        <>
            <nav className="shadow-md">
                <div className="flex justify-between p-5 bg-zinc-900">
                    <div>
                        <h3 className="text-zinc-200">Nome Logo</h3>
                    </div>
                    <div>
                        <ul className="flex justify-center">
                            <li className="text-zinc-200"><Link to="/">Card</Link></li>
                            <li className="text-zinc-200"><Link className="ml-2 mr-2" to="/flash">Flash</Link></li>
                            <li className="text-zinc-200"><Link to="/flashcard">Flashcard</Link></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </>
    )
}