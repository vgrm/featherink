import React from "react";
import { Row, Col, ListGroup, ListGroupItem, Image } from "react-bootstrap";
import { Link as RouterLink} from "react-router-dom";
import PropTypes from "prop-types";


import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import Link from '@material-ui/core/Link'

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
        padding: theme.spacing(2)
    },
    card: {
        maxWidth: 450,
        margin: theme.spacing(1),
        display: 'flex',
        flexDirection: 'column',
    },
    cardActionArea: {
        flexGrow: 1,
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'stretch',
    },
    media: {
        height: 140,
    },
    content: {
        flexGrow: 1,
    },
}));

function NewDesignerCard({ designers }) {
    NewDesignerCard.propTypes = {
        designers: PropTypes.array
    };

    const classes = useStyles();

    return (
        <div>
            <Grid
                container
                spacing={2}
                direction="row"
                justify="flex-start"
                alignItems="flex-start"
            >
                {designers.map(designer => (
                    <Grid item xs={12} sm={6} md={3} key={designer.id}>
                        <Card className={classes.card}>
                            
                            <CardActionArea className={classes.cardActionArea}>
                                <Link underline='none' component={RouterLink} to={`/designer/${designer.id}`}>
                                    <CardMedia
                                        className={classes.media}
                                        image={designer.image}
                                        title={designer.name + "_Image"}
                                    />
                                </Link>
                                    <CardContent className={classes.content}>
                                        <Typography gutterBottom variant="h5" component="h2">
                                            {designer.name}
                                        </Typography>
                                        <Typography variant="body2" color="textSecondary" component="p">
                                            {designer.description}
                                        </Typography>
                                    </CardContent>
                                </CardActionArea>
                            
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </div>
    );
}

class Designers extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            designers: []
        };

        fetch('api/designer')
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        designers: result
                    });
                });
    }


    render() {
        return (
            <div>
                <h1>Featherink designers</h1>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <NewDesignerCard {...this.state} />
                            </Col>
                        </Row>
                    </Col>

                </Row>
            </div>
        );
    }
}

export default Designers;