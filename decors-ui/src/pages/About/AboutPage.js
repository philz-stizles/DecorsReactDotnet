import React from 'react';
import styled from 'styled-components';
import { PageHero } from '../../components';
import aboutImg from '../../assets/images/hero-bcg.jpeg';

const AboutPage = () => {
  return (
    <main>
      <PageHero title="about" />
      <AboutPageWrapper className="page section section-center">
        <img src={aboutImg} alt="nice desk"></img>
        <article>
          <div className="title">
            <h2>our story</h2>
            <div className="underline"></div>
          </div>
          <p>
            Now that we know who you are, I know who I am. I'm not a mistake! It
            all makes sense! In a comic, you know how you can tell who the
            arch-villain's going to be? He's the exact opposite of the hero. And
            most times they're friends, like you and me! I should've known way
            back when... You know why, David? Because of the kids. They called
            me Mr Glass.
          </p>
        </article>
      </AboutPageWrapper>
    </main>
  );
};

const AboutPageWrapper = styled.section`
  display: grid;
  gap: 4rem;
  img {
    width: 100%;
    display: block;
    border-radius: var(--radius);
    height: 500px;
    object-fit: cover;
  }
  p {
    line-height: 2;
    max-width: 45em;
    margin: 0 auto;
    margin-top: 2rem;
    color: var(--clr-grey-5);
  }
  .title {
    text-align: left;
  }
  .underline {
    margin-left: 0;
  }
  @media (min-width: 992px) {
    grid-template-columns: 1fr 1fr;
  }
`;
export default AboutPage;
