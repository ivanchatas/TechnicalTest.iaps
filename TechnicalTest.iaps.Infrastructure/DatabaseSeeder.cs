using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TechnicalTest.iaps.Domain.Entities;
using TechnicalTest.iaps.Domain.Interfaces.Services;
using TechnicalTest.iaps.Infrastructure.Context;

namespace TechnicalTest.iaps.Infrastructure
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly TechnicalTestContext _db;
        public DatabaseSeeder(TechnicalTestContext db, ILogger<DatabaseSeeder> logger)
        {
            _db = db;
            _logger = logger;
        }

        public void Initialize()
        {
            //AddData();
            AddFirstData();
            _db.SaveChanges();
        }

        public void AddFirstData()
        {
            var papers = new List<Paper>() 
            {
                new Paper() 
                { 
                    Id = "0704.0001",
                    Submitter = "Pavel Nadolsky",
                    //Authors = "C. Bal\'azs, E. L. Berger, P. M. Nadolsky, C.-P. Yuan",
                    Title = "Calculation of prompt diphoton production cross sections at Tevatron and LHC energies",
                    Comments = "37 pages, 15 figures; published version",
                    JournalRef = "Phys.Rev.D76:013009,2007",
                    //Doi = "10.1103/PhysRevD.76.013009",
                    //ReportNo = "ANL-HEP-PR-07-12",
                    Categories = new Category[1] { new Category { Name = "hep-ph" }}.ToList(),
                    //License = null,
                    Abstract = " A fully differential calculation in perturbative quantum chromodynamics is presented for the production of massive photon pairs at hadron colliders. All next-to-leading order perturbative contributions from quark-antiquark, gluon-(anti)quark, and gluon-gluon subprocesses are included, as well as all-orders resummation of initial-state gluon radiation valid at next-to-next-to-leading logarithmic accuracy. The region of phase space is specified in which the calculation is most reliable. Good agreement is demonstrated with data from the Fermilab Tevatron, and predictions are made for more detailed tests with CDF and DO data. Predictions are shown for distributions of diphoton pairs produced at the energy of the Large Hadron Collider (LHC). Distributions of the diphoton pairs from the decay of a Higgs boson are contrasted with those produced from QCD processes at the LHC, showing that enhanced sensitivity to the signal can be obtained with judicious selection of events.",
                    Authors = new Author[4]
                    {
                        new Author { LastName = "Balázs", Name = "C." },
                        new Author { LastName = "Berger", Name = "E. L." },
                        new Author { LastName = "Nadolsky", Name = "P. M." },
                        new Author { LastName = "Yuan", Name = "C. -P." },
                    }.ToList(),
                    Versions = new PaperVersion[2]
                    {
                        new PaperVersion() { Version = "v1", Created = DateTime.Parse("Mon, 2 Apr 2007 19:18:42 GMT") },
                        new PaperVersion() { Version = "v2", Created = DateTime.Parse("Tue, 24 Jul 2007 20:10:27 GMT") }
                    }.ToList()
                },
                new Paper()
                {
                    Id = "0704.0002",
                    Submitter = "Louis Theran",
                    //Authors = "Ileana Streinu and Louis Theran",
                    Title = "Sparsity-certifying Graph Decompositions",
                    Comments = "To appear in Graphs and Combinatorics",
                    JournalRef = null,
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "math.CO cs.CG" }}.ToList(),
                    //License = "http://arxiv.org/licenses/nonexclusive-distrib/1.0/",
                    Abstract = "We describe a new algorithm, the $(k,\\ell)$-pebble game with colors, and use\nit obtain a characterization of the family of $(k,\\ell)$-sparse graphs and\nalgorithmic solutions to a family of problems concerning tree decompositions of\ngraphs. Special instances of sparse graphs appear in rigidity theory and have\nreceived increased attention in recent years. In particular, our colored\npebbles generalize and strengthen the previous results of Lee and Streinu and\ngive a new proof of the Tutte-Nash-Williams characterization of arboricity. We\nalso present a new decomposition that certifies sparsity based on the\n$(k,\\ell)$-pebble game with colors. Our work also exposes connections between\npebble game algorithms and previous sparse graph algorithms by Gabow, Gabow and\nWestermann and Hendrickson.\n",
                    Versions = new PaperVersion[2]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 02:26:18 GMT") },
                        new PaperVersion { Version = "v2", Created = DateTime.Parse("Sat, 13 Dec 2008 17:26:00 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2008-12-13"), 
                    Authors = new Author[2] {
                        new Author { LastName = "Streinu", Name = "Ileana" },
                        new Author { LastName = "Theran", Name = "Louis" }
                    }.ToList()
                },
                new Paper() 
                { 
                    Id = "0704.0003",
                    Submitter = "Hongjun Pan",
                    //"authors= "Hongjun Pan",
                    Title = "The evolution of the Earth-Moon system based on the dark matter field\n  fluid model",
                    Comments=  "23 pages, 3 figures",
                    JournalRef = null,
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "physics.gen-ph" }}.ToList(), 
                    //License = null,
                    Abstract = "The evolution of Earth-Moon system is described by the dark matter field\nfluid model proposed in the Meeting of Division of Particle and Field 2004,\nAmerican Physical Society. The current behavior of the Earth-Moon system agrees\nwith this model very well and the general pattern of the evolution of the\nMoon-Earth system described by this model agrees with geological and fossil\nevidence. The closest distance of the Moon to Earth was about 259000 km at 4.5\nbillion years ago, which is far beyond the Roche's limit. The result suggests\nthat the tidal friction may not be the primary cause for the evolution of the\nEarth-Moon system. The average dark matter field fluid constant derived from\nEarth-Moon system data is 4.39 x 10^(-22) s^(-1)m^(-1). This model predicts\nthat the Mars's rotation is also slowing with the angular acceleration rate\nabout -4.38 x 10^(-22) rad s^(-2).\n",
                    Versions = new PaperVersion[3]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Sun, 1 Apr 2007 20:46:54 GMT") },
                        new PaperVersion { Version = "v2", Created = DateTime.Parse("Sat, 8 Dec 2007 23:47:24 GMT") },
                        new PaperVersion { Version = "v3", Created = DateTime.Parse("Sun, 13 Jan 2008 00:36:28 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2008-01-13"), 
                    Authors = new Author[1] { new Author { LastName = "Pan", Name = "Hongjun" } }.ToList()
                },
                new Paper() 
                {
                    Id = "0704.0004",
                    Submitter = "David Callan",
                    //"authors= "David Callan",
                    Title = "A determinant of Stirling cycle numbers counts unlabeled acyclic\n  single-source automata",
                    Comments=  "11 pages",
                    JournalRef = null,
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "math.CO" }}.ToList(), 
                    //License = null,
                    Abstract = "We show that a determinant of Stirling cycle numbers counts unlabeled acyclic\nsingle-source automata. The proof involves a bijection from these automata to\ncertain marked lattice paths and a sign-reversing involution to evaluate the\ndeterminant.\n",
                    Versions = new PaperVersion[1]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 03:16:14 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2007-05-23"), 
                    Authors = new Author[1] { new Author { LastName = "Callan", Name = "David" } }.ToList()
                },
                new Paper() { 
                    Id = "0704.0005",
                    Submitter = "Alberto Torchinsky",
                    //"authors= "Wael Abu-Shammala and Alberto Torchinsky",
                    Title = "From dyadic $\\Lambda_{\\alpha}$ to $\\Lambda_{\\alpha}$",
                    Comments = null,
                    //"journal-ref= "Illinois J. Math. 52 (2008) no.2, 681-689",
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "math.CA math.FA" }}.ToList(), 
                    //License = null,
                    Abstract = "In this paper we show how to compute the $\\Lambda_{\\alpha}$ norm, $\\alpha\\ge\n0$, using the dyadic grid. This result is a consequence of the description of\nthe Hardy spaces $H^p(R^N)$ in terms of dyadic and special atoms.\n",
                    Versions = new PaperVersion[1]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Mon, 2 Apr 2007 18:09:58 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2013-10-15"), 
                    Authors = new Author[2] {
                        new Author { LastName = "Abu-Shammala", Name = "Wael" },
                        new Author { LastName = "Torchinsky", Name = "Alberto" }
                    }.ToList()
                },
                new Paper() 
                { 
                    Id = "0704.0006",
                    Submitter = "Yue Hin Pong",
                    //"authors= "Y. H. Pong and C. K. Law",
                    Title = "Bosonic characters of atomic Cooper pairs across resonance",
                    Comments=  "6 pages, 4 figures, accepted by PRA",
                    JournalRef = null,
                    //"doi= "10.1103/PhysRevA.75.043613",
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "cond-mat.mes-hall" }}.ToList(), 
                    //License = null,
                    Abstract = "We study the two-particle wave function of paired atoms in a Fermi gas with\ntunable interaction strengths controlled by Feshbach resonance. The Cooper pair\nwave function is examined for its bosonic characters, which is quantified by\nthe correction of Bose enhancement factor associated with the creation and\nannihilation composite particle operators. An example is given for a\nthree-dimensional uniform gas. Two definitions of Cooper pair wave function are\nexamined. One of which is chosen to reflect the off-diagonal long range order\n(ODLRO). Another one corresponds to a pair projection of a BCS state. On the\nside with negative scattering length, we found that paired atoms described by\nODLRO are more bosonic than the pair projected definition. It is also found\nthat at $(k_F a)^{-1} \\ge 1$, both definitions give similar results, where more\nthan 90% of the atoms occupy the corresponding molecular condensates.\n",
                    Versions = new PaperVersion[1]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 04:24:59 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2015-05-13"), 
                    Authors = new Author[2]
                    {
                        new Author { LastName = "Pong", Name = "Y. H." },
                        new Author { LastName = "Law", Name = "C. K." }
                    }.ToList()
                },
                new Paper() 
                { 
                    Id = "0704.0007",
                    Submitter = "Alejandro Corichi",
                    //"authors= "Alejandro Corichi, Tatjana Vukasinac and Jose A. Zapata"," +
                    Title = "Polymer Quantum Mechanics and its Continuum Limit",
                    Comments = "16 pages, no figures. Typos corrected to match published version",
                    JournalRef = "Phys.Rev.D76:044016,2007",
                    //"doi= "10.1103/PhysRevD.76.044016",
                    //"report-no= "IGPG-07/03-2",
                    Categories = new Category[1] { new Category() { Name = "gr-qc" }}.ToList(), 
                    //License = null,
                    Abstract = "A rather non-standard quantum representation of the canonical commutation\nrelations of quantum mechanics systems, known as the polymer representation has\ngained some attention in recent years, due to its possible relation with Planck\nscale physics. In particular, this approach has been followed in a symmetric\nsector of loop quantum gravity known as loop quantum cosmology. Here we explore\ndifferent aspects of the relation between the ordinary Schroedinger theory and\nthe polymer description. The paper has two parts. In the first one, we derive\nthe polymer quantum mechanics starting from the ordinary Schroedinger theory\nand show that the polymer description arises as an appropriate limit. In the\nsecond part we consider the continuum limit of this theory, namely, the reverse\nprocess in which one starts from the discrete theory and tries to recover back\nthe ordinary Schroedinger quantum mechanics. We consider several examples of\ninterest, including the harmonic oscillator, the free particle and a simple\ncosmological model.\n",
                    Versions = new PaperVersion[2]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 04:27:22 GMT") },
                        new PaperVersion { Version = "v2", Created = DateTime.Parse("Wed, 22 Aug 2007 22:42:11 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2008-11-26"), 
                    Authors = new Author[3] 
                    {
                        new Author { LastName = "Corichi", Name = "Alejandro" },
                        new Author { LastName = "Vukasinac", Name = "Tatjana" },
                        new Author { LastName = "Zapata", Name = "Jose A." }
                    }.ToList()
                },
                new Paper() 
                { 
                    Id = "0704.0008",
                    Submitter = "Damian Swift",
                    //"authors= "Damian C. Swift",
                    Title = "Numerical solution of shock and ramp compression for general material\n  properties",
                    Comments=  "Minor corrections",
                    JournalRef = "Journal of Applied Physics, vol 104, 073536 (2008)",
                    //"doi= "10.1063/1.2975338",
                    //"report-no= "LA-UR-07-2051, LLNL-JRNL-410358",
                    Categories = new Category[1] { new Category() { Name = "cond-mat.mtrl-sci" } }.ToList(),
                    //License= "http://arxiv.org/licenses/nonexclusive-distrib/1.0/",
                    Abstract = "A general formulation was developed to represent material models for\napplications in dynamic loading. Numerical methods were devised to calculate\nresponse to shock and ramp compression, and ramp decompression, generalizing\nprevious solutions for scalar equations of state. The numerical methods were\nfound to be flexible and robust, and matched analytic results to a high\naccuracy. The basic ramp and shock solution methods were coupled to solve for\ncomposite deformation paths, such as shock-induced impacts, and shock\ninteractions with a planar interface between different materials. These\ncalculations capture much of the physics of typical material dynamics\nexperiments, without requiring spatially-resolving simulations. Example\ncalculations were made of loading histories in metals, illustrating the effects\nof plastic work on the temperatures induced in quasi-isentropic and\nshock-release experiments, and the effect of a phase transition.\n",
                    Versions = new PaperVersion[3]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 04:47:20 GMT") },
                        new PaperVersion { Version = "v2", Created = DateTime.Parse("Thu, 10 Apr 2008 08:42:28 GMT") },
                        new PaperVersion { Version = "v3", Created = DateTime.Parse("Tue, 1 Jul 2008 18:54:28 GMT") } 
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2009-02-05"), 
                    Authors = new Author[1] { new Author { LastName = "Swift", Name = "Damian C." }}.ToList()
                },
                new Paper() 
                { 
                    Id = "0704.0009",
                    Submitter = "Paul Harvey",
                    //"authors= "Paul Harvey, Bruno Merin, Tracy L. Huard, Luisa M. Rebull, Nicholas\n  Chapman, Neal J. Evans II, Philip C. Myers",
                    Title = "The Spitzer c2d Survey of Large, Nearby, Insterstellar Clouds. IX. The\n  Serpens YSO Population As Observed With IRAC and MIPS",
                    Comments = null,
                    JournalRef = "Astrophys.J.663:1149-1173,2007",
                    //"doi= "10.1086/518646",
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "astro-ph" }}.ToList(), 
                    //License = null,
                    Abstract = "We discuss the results from the combined IRAC and MIPS c2d Spitzer Legacy\nobservations of the Serpens star-forming region. In particular we present a set\nof criteria for isolating bona fide young stellar objects, YSO's, from the\nextensive background contamination by extra-galactic objects. We then discuss\nthe properties of the resulting high confidence set of YSO's. We find 235 such\nobjects in the 0.85 deg^2 field that was covered with both IRAC and MIPS. An\nadditional set of 51 lower confidence YSO's outside this area is identified\nfrom the MIPS data combined with 2MASS photometry. We describe two sets of\nresults, color-color diagrams to compare our observed source properties with\nthose of theoretical models for star/disk/envelope systems and our own modeling\nof the subset of our objects that appear to be star+disks. These objects\nexhibit a very wide range of disk properties, from many that can be fit with\nactively accreting disks to some with both passive disks and even possibly\ndebris disks. We find that the luminosity function of YSO's in Serpens extends\ndown to at least a few x .001 Lsun or lower for an assumed distance of 260 pc.\nThe lower limit may be set by our inability to distinguish YSO's from\nextra-galactic sources more than by the lack of YSO's at very low luminosities.\nA spatial clustering analysis shows that the nominally less-evolved YSO's are\nmore highly clustered than the later stages and that the background\nextra-galactic population can be fit by the same two-point correlation function\nas seen in other extra-galactic studies. We also present a table of matches\nbetween several previous infrared and X-ray studies of the Serpens YSO\npopulation and our Spitzer data set.\n",
                    Versions = new PaperVersion[1] { new PaperVersion { Version = "v1", Created = DateTime.Parse("Mon, 2 Apr 2007 19:41:34 GMT") } }.ToList(),
                    UpdateDate = DateTime.Parse("2010-03-18"), 
                    Authors = new Author[7] {
                        new Author { LastName = "Harvey", Name = "Paul" },
                        new Author { LastName = "Merin", Name = "Bruno" },
                        new Author { LastName = "Huard", Name = "Tracy L." },
                        new Author { LastName = "Rebull", Name = "Luisa M." },
                        new Author { LastName = "Chapman", Name = "Nicholas" },
                        new Author { LastName = "Evans", Name = "Neal J.", Initials = "II" },
                        new Author { LastName = "Myers", Name = "Philip C." }
                    }.ToList()
                },
                new Paper() 
                { 
                    Id = "0704.0010",
                    Submitter = "Sergei Ovchinnikov",
                    //"authors= "Sergei Ovchinnikov",
                    Title = "Partial cubes: structures, characterizations, and constructions",
                    Comments = "36 pages, 17 figures",
                    JournalRef = null,
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "math.CO" }}.ToList(), 
                    //License = null,
                    Abstract = "Partial cubes are isometric subgraphs of hypercubes. Structures on a graph\ndefined by means of semicubes, and Djokovi\\'{c}'s and Winkler's relations play\nan important role in the theory of partial cubes. These structures are employed\nin the paper to characterize bipartite graphs and partial cubes of arbitrary\ndimension. New characterizations are established and new proofs of some known\nresults are given.\n  The operations of Cartesian product and pasting, and expansion and\ncontraction processes are utilized in the paper to construct new partial cubes\nfrom old ones. In particular, the isometric and lattice dimensions of finite\npartial cubes obtained by means of these operations are calculated.\n",
                    Versions = new PaperVersion[1] { new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 05:10:16 GMT") }}.ToList(),
                    UpdateDate = DateTime.Parse("2007-05-23"),
                    Authors = new Author[1] { new Author { LastName = "Ovchinnikov", Name = "Sergei" } }.ToList()
                },
                new Paper()
                {
                    Id = "0704.0011",
                    Submitter = "Clifton Cunningham",
                    //"authors= "Clifton Cunningham and Lassina Dembele",
                    Title = "Computing genus 2 Hilbert-Siegel modular forms over $\\Q(\\sqrt{5})$ via\n the Jacquet-Langlands correspondence",
                    Comments = "14 pages; title changed; to appear in Experimental Mathematics",
                    JournalRef = null,
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "math.NT math.AG" } }.ToList(),
                    //License= "http://arxiv.org/licenses/nonexclusive-distrib/1.0/",
                    Abstract = "In this paper we present an algorithm for computing Hecke eigensystems of\nHilbert-Siegel cusp forms over real quadratic fields of narrow class number\none. We give some illustrative examples using the quadratic field\n$\\Q(\\sqrt{5})$. In those examples, we identify Hilbert-Siegel eigenforms that\nare possible lifts from Hilbert eigenforms.\n",
                    Versions = new PaperVersion[3]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 05:32:49 GMT") },
                        new PaperVersion { Version = "v2", Created = DateTime.Parse("Tue, 19 Aug 2008 04:46:47 GMT") },
                        new PaperVersion { Version = "v3", Created = DateTime.Parse("Wed, 20 Aug 2008 13:15:09 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2008-08-20"),
                    Authors = new Author[2] { 
                        new Author { LastName = "Cunningham", Name = "Clifton" },
                        new Author { LastName = "Dembele", Name = "Lassina", }
                    }.ToList()
                },
                new Paper()
                {
                    Id = "0704.0012",
                    Submitter = "Dohoon Choi",
                    //"authors= "Dohoon Choi",
                    Title = "Distribution of integral Fourier Coefficients of a Modular Form of Half\n  Integral Weight Modulo Primes",
                    Comments = null,
                    JournalRef = null,
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "math.NT" }}.ToList(),
                    //License = null,
                    Abstract = "Recently, Bruinier and Ono classified cusp forms $f(z) := \\sum_{n=0}^{\\infty}\na_f(n)q ^n \\in S_{\\lambda+1/2}(\\Gamma_0(N),\\chi)\\cap \\mathbb{Z}[[q]]$ that does\nnot satisfy a certain distribution property for modulo odd primes $p$. In this\npaper, using Rankin-Cohen Bracket, we extend this result to modular forms of\nhalf integral weight for primes $p \\geq 5$. As applications of our main theorem\nwe derive distribution properties, for modulo primes $p\\geq5$, of traces of\nsingular moduli and Hurwitz class number. We also study an analogue of Newman's\nconjecture for overpartitions.\n",
                    Versions = new PaperVersion[1] { new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 05:48:51 GMT") } }.ToList(),
                    UpdateDate = DateTime.Parse("2007-05-23"),
                    Authors = new Author[1] { new Author { LastName = "Choi", Name = "Dohoon" } }.ToList()
                },
                new Paper()
                {
                    Id = "0704.0013",
                    Submitter = "Dohoon Choi",
                    //"authors= "Dohoon Choi and YoungJu Choie",
                    Title = "$p$-adic Limit of Weakly Holomorphic Modular Forms of Half Integral\n  Weight",
                    Comments = null,
                    JournalRef = null,
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "math.NT" } }.ToList(),
                    //License = null,
                    Abstract = "Serre obtained the p-adic limit of the integral Fourier coefficient of\nmodular forms on $SL_2(\\mathbb{Z})$ for $p=2,3,5,7$. In this paper, we extend\nthe result of Serre to weakly holomorphic modular forms of half integral weight\non $\\Gamma_{0}(4N)$ for $N=1,2,4$. A proof is based on linear relations among\nFourier coefficients of modular forms of half integral weight. As applications\nwe obtain congruences of Borcherds exponents, congruences of quotient of\nEisentein series and congruences of values of $L$-functions at a certain point\nare also studied. Furthermore, the congruences of the Fourier coefficients of\nSiegel modular forms on Maass Space are obtained using Ikeda lifting.\n",
                    Versions = new PaperVersion[2]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 06:21:49 GMT") },
                        new PaperVersion { Version = "v2", Created = DateTime.Parse("Mon, 26 May 2008 03:31:52 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2008-05-26"),
                    Authors = new Author[2] { 
                        new Author { LastName = "Choi", Name = "Dohoon" },
                        new Author { LastName = "Choie", Name = "YoungJu" }
                    }.ToList()
                },
                new Paper() 
                { 
                    Id = "0704.0014",
                    Submitter = "Koichi Fujii",
                    //"authors= "Koichi Fujii",
                    Title = "Iterated integral and the loop product",
                    Comments=  "18 pages, 1 figure",
                    JournalRef = null,
                    //"doi":null,
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "math.CA math.AT" }}.ToList(), 
                    //License = null,
                    Abstract = "In this article we discuss a relation between the string topology and\ndifferential forms based on the theory of Chen's iterated integrals and the\ncyclic bar complex.\n",
                    Versions = new PaperVersion[1] { new PaperVersion { Version = "v1", Created = DateTime.Parse("Sun, 1 Apr 2007 12:04:13 GMT") }}.ToList(),
                    UpdateDate = DateTime.Parse("2009-09-29"), 
                    Authors = new Author[1] { new Author { LastName = "Fujii", Name = "Koichi" }}.ToList()
                },
                new Paper() 
                { 
                    Id = "0704.0015",
                    Submitter = "Christian Stahn",
                    //"authors= "Christian Stahn",
                    Title = "Fermionic superstring loop amplitudes in the pure spinor formalism",
                    Comments=  "22 pages; signs and coefficients adjusted for anticommuting\n  superfields, section 4.3 changed accordingly, reference added",
                    JournalRef = "JHEP 0705:034,2007",
                    //"doi= "10.1088/1126-6708/2007/05/034",
                    //"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "hep-th" }}.ToList(), 
                    //License = null,
                    Abstract = "The pure spinor formulation of the ten-dimensional superstring leads to\nmanifestly supersymmetric loop amplitudes, expressed as integrals in pure\nspinor superspace. This paper explores different methods to evaluate these\nintegrals and then uses them to calculate the kinematic factors of the one-loop\nand two-loop massless four-point amplitudes involving two and four Ramond\nstates.\n",
                    Versions = new PaperVersion[2]
                    {
                        new PaperVersion { Version = "v1", Created = DateTime.Parse("Mon, 2 Apr 2007 18:10:09 GMT") },
                        new PaperVersion { Version = "v2", Created = DateTime.Parse("Mon, 10 Mar 2008 04:18:38 GMT") }
                    }.ToList(),
                    UpdateDate = DateTime.Parse("2009-11-13"), 
                    Authors = new Author[1] { new Author { LastName = "Stahn", Name = "Christian" }}.ToList(),
                },
                new Paper() 
                { 
                    Id = "0704.0016",
                    Submitter = "Li Tong",
                    //"authors= "Chao-Hsi Chang, Tong Li, Xue-Qian Li and Yu-Ming Wang",
                    Title = "Lifetime of doubly charmed baryons",
                    Comments = "17 pages, 3 figures and 1 table",
                    JournalRef = "Commun.Theor.Phys.49:993-1000,2008",
                    //"doi= "10.1088/0253-6102/49/4/38",//"report-no":null,
                    Categories = new Category[1] { new Category() { Name = "hep-ph" }}.ToList(), 
                    //License = null,
                    Abstract = "In this work, we evaluate the lifetimes of the doubly charmed baryons\n$\\Xi_{cc}^{+}$, $\\Xi_{cc}^{++}$ and $\\Omega_{cc}^{+}$. We carefully calculate\nthe non-spectator contributions at the quark level where the Cabibbo-suppressed\ndiagrams are also included. The hadronic matrix elements are evaluated in the\nsimple non-relativistic harmonic oscillator model. Our numerical results are\ngenerally consistent with that obtained by other authors who used the diquark\nmodel. However, all the theoretical predictions on the lifetimes are one order\nlarger than the upper limit set by the recent SELEX measurement. This\ndiscrepancy would be clarified by the future experiment, if more accurate\nexperiment still confirms the value of the SELEX collaboration, there must be\nsome unknown mechanism to be explored.\n",
                    Versions = new PaperVersion[1] { new PaperVersion { Version = "v1", Created = DateTime.Parse("Sat, 31 Mar 2007 07:04:26 GMT") }}.ToList(),
                    UpdateDate = DateTime.Parse("2008-12-18"), 
                    Authors = new Author[4]
                    {
                        new Author { LastName = "Chang", Name = "Chao-Hsi" },
                        new Author { LastName = "Li", Name = "Tong" },
                        new Author { LastName = "Li", Name = "Xue-Qian" },
                        new Author { LastName = "Wang", Name = "Yu-Ming" }
                    }.ToList()
                },
            };

            _db.Papers.AddRange(papers);
        }

        public void AddData() 
        {
            string path = @"C:/arxiv-metadata-oai-snapshot.json";
            string json = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<Paper>(json);
        }
    }
}