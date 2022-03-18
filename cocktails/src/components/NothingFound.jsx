import { Jumbotron } from 'reactstrap';

const NothingFound = props => {
    return (
        <Jumbotron className="mt-2">
            <h1 className="display-4">Lets Drink Something</h1>
            <p className="lead">Example React application based on TheCoctailDB API.</p>
        </Jumbotron>
    );
}

export default NothingFound;