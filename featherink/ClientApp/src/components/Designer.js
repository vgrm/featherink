import React from "react";
import { Row, Col, ListGroup, ListGroupItem, Image } from "react-bootstrap";
//import { Link } from "react-router-dom";
import PropTypes from "prop-types";


import { makeStyles, withStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import Container from '@material-ui/core/Container';
import Link from '@material-ui/core/Link';

import colors from "../Constants/colors";

const ColorButton = withStyles(theme => ({
    root: {
        color: colors.white,
        backgroundColor: colors.primaryColor,
        '&:hover': {
            backgroundColor: colors.primaryColorDark,
        },
    },
}))(Button);

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
        padding: theme.spacing(2)
    },
    card: {
        height: '100%',
        display: 'flex',
        flexDirection: 'column',
    },
    cardMedia: {
        paddingTop: '56.25%', // 16:9
    },
    media: {
        height: 140,
    },
    heroContent: {
        backgroundColor: theme.palette.background.paper,
        padding: theme.spacing(8, 0, 6),
    },
    heroButtons: {
        marginTop: theme.spacing(4),
    },

}));

function ArtGrid({arts }) {
    ArtGrid.propTypes = {
        arts: PropTypes.array
    };

    const classes = useStyles();

    return (
        <Container className={classes.cardGrid} maxWidth="md">
            {/* End hero unit */}
            <Grid container spacing={4}>
                {arts.map(art => (
                    <Grid item key={art.id} xs={12} sm={6} md={4}>
                        <Card className={classes.card}>
                            <CardMedia
                                className={classes.cardMedia}
                                image={art.image}
                                title={art.name + "_Image"}
                            />
                            <CardContent className={classes.cardContent}>
                                <Typography gutterBottom variant="h5" component="h2">
                                    {art.name}
                    </Typography>
                                <Typography variant="caption" display="block" gutterBottom>
                                    {art.description}
                    </Typography>
                            </CardContent>
                            <CardActions>
                                <Button size="small" color="primary">
                                    View
                    </Button>
                                <Button size="small" color="primary">
                                    Edit
                    </Button>
                            </CardActions>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </Container>
        );

}
function DesignerPage({ designer }) {
    DesignerPage.propTypes = {
        designer: PropTypes.object
    };

    const classes = useStyles();

    return (
        <div>
            <div className={classes.heroContent}>
                <Container maxWidth="sm">
                    <Typography component="h1" variant="h2" align="center" color="textPrimary" gutterBottom>
                        {designer.name}
                    </Typography>
                    <Typography variant="h5" align="center" color="textSecondary" paragraph>
                        {designer.description}
                    </Typography>
                    <div className={classes.heroButtons}>
                        <Grid container spacing={2} justify="center">
                            <Grid item>
                                <Link href="/tasknew" variant="body2" color="inherit">
                                    <ColorButton variant="contained" color="primary">
                                        Order
                  </ColorButton>
              </Link>
                            </Grid>
                            <Grid item>
                                <ColorButton variant="outlined" color="primary">
                                    Upload art
                  </ColorButton>
                            </Grid>
                        </Grid>
                    </div>
                </Container>
            </div>           

        </div>
    );
}

class Designer extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            designerId: this.props.match.params.designerId,
            designer: { arts: [] },
            arts: []
        };

        Designer.propTypes = {
            designerId: PropTypes.number,
            designer: PropTypes.object,
            arts: PropTypes.array,
            match: PropTypes.object
        };
    }
    componentDidMount() {
        fetch(`api/designer/${this.state.designerId}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        designer: result,
                        error: result.error
                    });
                },
                (error) => {
                    this.setState({
                        error: error
                    });
                }
        );

        fetch(`api/art`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        arts: result.filter(x => x.designerId == this.state.designerId)
                    });
                }
        );

    }


    render() {
        return (
            <div>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <DesignerPage {...this.state} />
                            </Col>
                        </Row>
                    </Col>

                </Row>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <ArtGrid arts={this.state.arts} />
                            </Col>
                        </Row>
                    </Col>

                </Row>
            </div>
        );
    }
}

export default Designer;