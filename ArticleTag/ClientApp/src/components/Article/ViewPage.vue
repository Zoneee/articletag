<template>
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- 不允许跨标签标记 -->
  <!-- double Tag -->

  <el-container class="index-container">
    <el-main>
      <div>
        <div class="article">
          <body class="article">
            <div class="grid">
              <div class="col twelve_col nomargin shadow">
                <!-- System messages like service outage or JS required; this is handled by the TemplateResources portlet -->
                <div class="sysmessages">
                  <noscript>
                    <p class="nojs">
                      <strong>Warning:</strong>
                      The NCBI web site requires JavaScript to function.
                      <a title="Learn how to enable JavaScript" target="_blank"
                        >more...</a
                      >
                    </p>
                  </noscript>
                </div>
                <!--/.sysmessage-->
                <div class="wrap">
                  <div class="page">
                    <div class="top">
                      <div class="universal_header" id="universal_header">
                        <ul
                          class="inline_list jig-ncbimenu ui-ncbimenu resources_list"
                          id="navcontent"
                        >
                          <li
                            class="ui-ncbimenu-item-leaf ui-ncbimenu-item-first ui-helper-reset ui-ncbimenu-item-no-hlt"
                          >
                            <a
                              class="ui-ncbimenu-link-first"
                              role="banner"
                              title="NCBI Home"
                              id="ncbihome"
                              accesskey="1"
                              ><span class="offscreen_noflow">NCBI</span>
                              <img
                                src=""
                                class="ncbi_logo"
                                title="NCBI"
                                alt="NCBI Logo"
                              />
                            </a>
                          </li>
                          <li
                            class="offscreen_noflow ui-ncbimenu-item-skip access"
                          >
                            <a
                              title="Skip to the content"
                              tabindex="0"
                              accesskey="3"
                              >Skip to main content</a
                            >
                          </li>
                          <li
                            class="offscreen_noflow ui-ncbimenu-item-skip access"
                          >
                            <a
                              title="Skip to the navigation"
                              tabindex="0"
                              accesskey="4"
                              >Skip to navigation</a
                            >
                          </li>
                          <li
                            id="resource-menu"
                            class="topmenu ui-helper-reset ui-ncbimenu-item-first ui-helper-reset"
                          >
                            <a
                              class="ui-ncbimenu-first-link-has-submenu ui-ncbimenu-link-first topanchor expandDown"
                              >Resources</a
                            >
                          </li>
                          <li
                            id="all-howtos-menu"
                            class="topmenu ui-helper-reset ui-ncbimenu-item-first"
                          >
                            <a
                              class="ui-ncbimenu-first-link-has-submenu ui-ncbimenu-link-first topanchor expandDown"
                              >How To</a
                            >
                          </li>
                          <li
                            class="offscreen_noflow ui-ncbimenu-item-skip access"
                          >
                            <a
                              title="About My NCBI Accesskeys"
                              tabindex="0"
                              accesskey="0"
                              >About NCBI Accesskeys</a
                            >
                          </li>
                        </ul>
                        <div class="myncbi">
                          <span id="myncbiusername" style="display: none"
                            ><a id="mnu" title="Edit account settings"></a>
                          </span>
                          <a accesskey="2" id="myncbi" style="display: none"
                            >My NCBI</a
                          >
                          <a id="sign_in">Sign in to NCBI</a>
                          <a id="sign_out" style="display: none">Sign Out</a>
                        </div>
                      </div>
                      <div class="header">
                        <div class="res_logo">
                          <h1 class="img_logo">
                            <a class="pmc_logo offscreen">PMC</a>
                          </h1>
                          <div class="NLMLogo">
                            <a title="US National Library of Medicine"
                              >US National Library of Medicine</a
                            >
                            <br />
                            <a title="National Institutes of Health"
                              >National Institutes of Health</a
                            >
                          </div>
                        </div>
                        <div class="search">
                          <form method="get" action="/pmc/">
                            <div class="search_form">
                              <label for="database" class="offscreen_noflow"
                                >Search database</label
                              >
                              <select id="database">
                                <optgroup label="Recent">
                                  <option
                                    value="pmc"
                                    selected="selected"
                                    class="last"
                                    data-ac_dict="pmc-search-autocomplete"
                                  >
                                    PMC
                                  </option>
                                </optgroup>
                                <optgroup label="All">
                                  <option value="gquery">All Databases</option>
                                  <option value="assembly">Assembly</option>
                                  <option value="biocollections">
                                    Biocollections
                                  </option>
                                  <option value="bioproject">BioProject</option>
                                  <option value="biosample">BioSample</option>
                                  <option value="biosystems">BioSystems</option>
                                  <option value="books">Books</option>
                                  <option value="clinvar">ClinVar</option>
                                  <option value="cdd">Conserved Domains</option>
                                  <option value="gap">dbGaP</option>
                                  <option value="dbvar">dbVar</option>
                                  <option value="gene">Gene</option>
                                  <option value="genome">Genome</option>
                                  <option value="gds">GEO DataSets</option>
                                  <option value="geoprofiles">
                                    GEO Profiles
                                  </option>
                                  <option value="gtr">GTR</option>
                                  <option value="homologene">HomoloGene</option>
                                  <option value="ipg">
                                    Identical Protein Groups
                                  </option>
                                  <option value="medgen">MedGen</option>
                                  <option value="mesh">MeSH</option>
                                  <option value="ncbisearch">
                                    NCBI Web Site
                                  </option>
                                  <option value="nlmcatalog">
                                    NLM Catalog
                                  </option>
                                  <option value="nuccore">Nucleotide</option>
                                  <option value="omim">OMIM</option>
                                  <option
                                    value="pmc"
                                    data-ac_dict="pmc-search-autocomplete"
                                  >
                                    PMC
                                  </option>
                                  <option value="popset">PopSet</option>
                                  <option value="protein">Protein</option>
                                  <option value="proteinclusters">
                                    Protein Clusters
                                  </option>
                                  <option value="pcassay">
                                    PubChem BioAssay
                                  </option>
                                  <option value="pccompound">
                                    PubChem Compound
                                  </option>
                                  <option value="pcsubstance">
                                    PubChem Substance
                                  </option>
                                  <option value="pubmed">PubMed</option>
                                  <option value="snp">SNP</option>
                                  <option value="sparcle">Sparcle</option>
                                  <option value="sra">SRA</option>
                                  <option value="structure">Structure</option>
                                  <option value="taxonomy">Taxonomy</option>
                                  <option value="toolkit">ToolKit</option>
                                  <option value="toolkitall">ToolKitAll</option>
                                  <option value="toolkitbookgh">
                                    ToolKitBookgh
                                  </option>
                                </optgroup>
                              </select>
                              <div class="nowrap">
                                <label
                                  for="term"
                                  class="offscreen_noflow"
                                  accesskey="/"
                                  >Search term</label
                                >
                                <div class="nowrap">
                                  <input
                                    type="text"
                                    name="term"
                                    id="term"
                                    title="Search PMC. Use up and down arrows to choose an item from the autocomplete."
                                    value=""
                                    class="jig-ncbiclearbutton jig-ncbiautocomplete"
                                    data-jigconfig="dictionary:'pmc-search-autocomplete',disableUrl:'NcbiSearchBarAutoComplCtrl'"
                                    autocomplete="off"
                                    data-sbconfig="ds:'no',pjs:'no',afs:'yes'"
                                  />
                                </div>
                                <button
                                  id="search"
                                  type="submit"
                                  class="button_search nowrap"
                                  cmd="go"
                                >
                                  Search
                                </button>
                              </div>
                            </div>
                          </form>
                          <ul class="searchlinks inline_list">
                            <li>
                              <a>Advanced</a>
                            </li>
                            <li>
                              <a>Journal list</a>
                            </li>
                            <li class="help">
                              <a target="_blank">Help</a>
                            </li>
                          </ul>
                        </div>
                      </div>

                      <!--<component id="Page" label="headcontent"/>-->
                    </div>
                    <div class="content">
                      <!-- site messages -->
                      <div class="container">
                        <div id="maincontent" class="content eight_col col">
                          <div class="navlink-box">
                            <ul class="page-breadcrumbs inline_list small">
                              <li class="journal-list">
                                <a class="navlink">Journal List</a>
                              </li>
                              <li class="article-entrez-filter">
                                <a class="navlink">HHS Author Manuscripts</a>
                              </li>
                              <li class="accid">PMC2597528</li>
                            </ul>
                          </div>

                          <!-- Journal banner -->
                          <div class="pmc-page-banner whole_rhythm">
                            <div>
                              <img
                                src=""
                                alt="Logo of nihpa"
                                usemap="#logo-imagemap"
                              />
                              <map id="logo-imagemap" name="logo-imagemap"
                                ><area
                                  shape="rect"
                                  coords="0,57,255,75"
                                  alt="About Author manuscripts"
                                  title="About Author manuscripts"
                                  ref="https://www.ncbi.nlm.nih.gov/pmc/about/authorms.html"
                                />
                                <area
                                  shape="rect"
                                  coords="256,57,500,75"
                                  alt="Submit a manuscript"
                                  title="Submit a manuscript"
                                  ref="reftype=publisher&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CBanner&amp;TO=Publisher%7COther%7CN/A"
                                  target="pmc_ext"
                                />
                                <area
                                  shape="rect"
                                  coords="0,0,499,74"
                                  alt="HHS Public Access; Author Manuscript; Accepted for publication in peer reviewed journal;"
                                  title="HHS Public Access; Author Manuscript; Accepted for publication in peer reviewed journal;"
                                  ref="reftype=publisher&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CBanner&amp;TO=Publisher%7COther%7CN/A"
                                  target="pmc_ext"
                                />
                              </map>
                            </div>
                          </div>

                          <!--component id='MainPortlet' label='search-reference'/-->

                          <!-- Book content -->
                          <div class="">
                            <div
                              class="hide-overflow article lit-style content pmc-wm slang-all page-box"
                            >
                              <!--main-content-->
                              <div
                                class="jig-ncbiinpagenav"
                                data-jigconfig="smoothScroll: false, allHeadingLevels: ['h2'], headingExclude: ':hidden'"
                              >
                                <div class="fm-sec half_rhythm no_top_margin">
                                  <div
                                    class="fm-citation half_rhythm no_top_margin clearfix"
                                  >
                                    <div class="inline_block eight_col va_top">
                                      <div>
                                        <span id="pmcmata">J Am Chem Soc</span>.
                                        Author manuscript; available in PMC 2008
                                        Dec 8.
                                      </div>
                                      <div></div>
                                      <div>
                                        Published in final edited form as:
                                      </div>
                                      <div style="margin-left: 1em">
                                        <div class="fm-vol-iss-date">
                                          <a
                                            target="pmc_ext"
                                            ref="reftype=publisher&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CFront%20Matter&amp;TO=Content%20Provider%7CArticle%7CRestricted%20Access"
                                            ><span class="cit"
                                              >J Am Chem Soc. 2006 May 3;
                                              128(17): 5966\xe2\x80\x935973.
                                            </span>
                                          </a>
                                        </div>
                                        <span class="doi"
                                          >doi:\xc2\xa0<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CFront%20Matter&amp;TO=Content%20Provider%7CCrosslink%7CDOI"
                                            >10.1021/ja0603958</a
                                          >
                                        </span>
                                      </div>
                                    </div>
                                    <div
                                      class="inline_block four_col va_top show-overflow align_right"
                                    >
                                      <div class="fm-citation-ids">
                                        <div class="fm-citation-pmcid">
                                          <span class="fm-citation-ids-label"
                                            >PMCID:
                                          </span>
                                          <span>PMC2597528</span>
                                        </div>
                                        <div class="fm-citation-manuscriptid">
                                          <span class="fm-citation-ids-label"
                                            >NIHMSID:
                                          </span>
                                          <span>NIHMS60994</span>
                                        </div>
                                        <div class="fm-citation-pmid">
                                          PMID: <a>16637665</a>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                  <h1 class="content-title">
                                    Engineering the Quadruplex Fold
                                  </h1>
                                  <div class="fm-subtitle">
                                    Nucleoside Conformation Determines Both
                                    Folding Topology and Molecularity in Guanine
                                    Quadruplexes
                                  </div>
                                  <div class="half_rhythm">
                                    <div class="contrib-group fm-author">
                                      <a>Chung-Fei Tang</a> and
                                      <a>Richard H. Shafer</a>
                                    </div>
                                    <div
                                      style="display: none"
                                      class="contrib-group aff-tip"
                                    ></div>
                                  </div>
                                  <div class="fm-panel half_rhythm">
                                    <div class="togglers">
                                      <a
                                        class="pmctoggle"
                                        rid="idm139857529222608_ai"
                                        >Author information</a
                                      >
                                      <a
                                        class="pmctoggle"
                                        rid="idm139857529222608_cpl"
                                        >Copyright and License information</a
                                      >
                                      <a>Disclaimer</a>
                                    </div>
                                    <div
                                      class="fm-authors-info fm-panel hide half_rhythm"
                                      id="idm139857529222608_ai"
                                      style="display: none"
                                    >
                                      <div class="fm-affl" lang="en" id="A1">
                                        Department of Pharmaceutical Chemistry,
                                        School of Pharmacy and Graduate Group in
                                        Chemistry and Chemical Biology,
                                        University of California, San Francisco,
                                        CA 94143-0446
                                      </div>
                                      <div id="CR1">
                                        E-mail:
                                        <a
                                          data-email="ude.fscu.lgc@refahs"
                                          class="oemail"
                                          >ude.fscu.lgc@refahs</a
                                        >
                                      </div>
                                    </div>
                                    <div
                                      class="fm-article-notes fm-panel half_rhythm"
                                    ></div>
                                    <div
                                      class="permissions fm-panel half_rhythm hide"
                                      id="idm139857529222608_cpl"
                                      style="display: none"
                                    >
                                      <div class="fm-copyright half_rhythm">
                                        <a>Copyright notice</a>
                                      </div>
                                    </div>
                                  </div>
                                  <div
                                    id="pmclinksbox"
                                    class="links-box whole_rhythm"
                                  >
                                    <div class="fm-panel">
                                      <div>
                                        The publisher's final edited version of
                                        this article is available at
                                        <a
                                          target="pmc_ext"
                                          ref="reftype=publisher&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CFront%20Matter&amp;TO=Content%20Provider%7CArticle%7CRestricted%20Access"
                                          >J Am Chem Soc</a
                                        >
                                      </div>
                                      <div>
                                        See other articles in PMC that
                                        <a>cite</a> the published article.
                                      </div>
                                    </div>
                                  </div>
                                </div>
                                <div class="sec"></div>
                                <div
                                  id="idm139857521661728"
                                  lang="en"
                                  class="tsec sec"
                                >
                                  <h2
                                    class="head no_bottom_margin"
                                    id="idm139857521661728title"
                                  >
                                    Abstract
                                  </h2>
                                  <!--article-meta-->
                                  <div>
                                    <p id="P1" class="p p-first-last">
                                      Nucleic acid quadruplexes, based on the
                                      guanine quartet, can arise from one or
                                      several strands, depending on the
                                      sequence. Those consisting of a single
                                      strand are folded in one of two principal
                                      topologies: antiparallel, in which all or
                                      half the guanine stretches are
                                      antiparallel to each other, or parallel,
                                      in which all guanine stretches are
                                      parallel to each other. In the latter, all
                                      guanine nucleosides possess the anti
                                      conformation about the glycoside bond
                                      while in the former, half possess the anti
                                      conformation, half the syn conformation.
                                      While antiparallel is the more common
                                      fold, examples of biologically important,
                                      parallel quadruplexes are becoming
                                      increasingly common. Thus it is of
                                      interest to understand the forces that
                                      determine the quadruplex fold. Here we
                                      examine the influence of individual
                                      nucleoside conformation on the overall
                                      folding topology by selective substitution
                                      of rG for dG. We can reverse the
                                      antiparallel fold of the thrombin binding
                                      aptamer (TBA) by this approach.
                                      Additionally, this substitution converts a
                                      unimolecular quadruplex into a bimolecular
                                      one. Similar reverse substitutions in the
                                      all-RNA analog of TBA result in a parallel
                                      to antiparallel change in topology and
                                      alter the strand configuration from
                                      bimolecular to unimolecular. Based on the
                                      specific substitutions made, we conclude
                                      that the strong preference of guanine
                                      ribonucleosides for the anti conformation
                                      is the driving force for the change in
                                      topology. These results demonstrate how
                                      conformational properties of guanine
                                      nucleosides govern not only the quadruplex
                                      folding topology but also impact
                                      quadruplex molecularity and provide a
                                      means to control these properties.
                                    </p>
                                  </div>
                                </div>
                                <div id="S1" class="tsec sec">
                                  <h2
                                    class="head no_bottom_margin"
                                    id="S1title"
                                  >
                                    Introduction
                                  </h2>
                                  <p id="P2" class="p p-first">
                                    Nucleic acid quadruplexes, based on the
                                    guanine quartet (see
                                    <a
                                      target="figure"
                                      class="fig-table-link figpopup"
                                      rid-figpopup="F1"
                                      rid-ob="ob-F1"
                                      co-legend-rid="lgnd_F1"
                                      ><span>Figure 1A</span> </a
                                    >), comprise a class of unusual DNA and RNA
                                    structures which have been shown to be
                                    relevant to a variety of biological
                                    functions
                                    <sup
                                      ><a
                                        rid="R1"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393621"
                                        >1</a
                                      > </sup
                                    >. For example, the human telomere sequence
                                    is known to form quadruplex structures under
                                    certain conditions, and this structure is
                                    thought to be involved in the regulation of
                                    telomerase activity
                                    <sup
                                      ><a
                                        rid="R2"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393664"
                                        >2</a
                                      > </sup
                                    >. In the <em>c-myc</em> promoter control
                                    region, evidence has been reported for a
                                    role of an intramolecular quadruplex in
                                    transcription regulation
                                    <sup
                                      ><a rid="R3" class="bibr popnode"
                                        >3</a
                                      > </sup
                                    >. These two activities suggest that
                                    quadruplexes may be new chemotherapeutic
                                    targets, and indeed this is being pursued by
                                    a variety of research groups
                                    <sup
                                      ><a rid="R4" class="bibr popnode"
                                        >4</a
                                      > </sup
                                    >. In addition to serving as potential drug
                                    targets, some quadruplexes have been
                                    observed to possess therapeutic activity
                                    <sup
                                      ><a
                                        rid="R5"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393618"
                                        >5</a
                                      >
                                    </sup>
                                    <sup>, </sup>
                                    <sup
                                      ><a
                                        rid="R6"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393640"
                                        >6</a
                                      > </sup
                                    >. While most of these studies involve DNA
                                    quadruplexes, there has also been interest
                                    in the biological roles played by RNA
                                    quadruplexes
                                    <sup
                                      ><a
                                        rid="R7"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393639"
                                        >7</a
                                      > </sup
                                    >.
                                  </p>
                                  <!--fig ft0--><!--fig mode=article f1-->
                                  <div
                                    class="fig iconblock whole_rhythm clearfix"
                                    id="F1"
                                    co-legend-rid="lgnd_F1"
                                  >
                                    <a
                                      target="figure"
                                      rid-figpopup="F1"
                                      rid-ob="ob-F1"
                                      ><!--fig/graphic|fig/alternatives/graphic mode="anchored" m1-->
                                      <div
                                        data-largeobj=""
                                        data-largeobj-link-rid="largeobj_idm139857515980112"
                                        class="figure"
                                      >
                                        <img
                                          class="fig-image"
                                          alt="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0001.jpg"
                                          title="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0001.jpg"
                                          src="http://img.staging.deepbiogroup.com/AptamerImageTotals/774568600000.jpg"
                                        />
                                      </div>
                                      <div
                                        id="largeobj_idm139857515980112"
                                        class="largeobj-link align_right"
                                        style="display: none"
                                      >
                                        <a target="object"
                                          >Open in a separate window</a
                                        >
                                      </div>
                                    </a>
                                    <div class="icnblk_cntnt" id="lgnd_F1">
                                      <div>
                                        <a
                                          class="figpopup"
                                          target="figure"
                                          rid-figpopup="F1"
                                          rid-ob="ob-F1"
                                          >Figure 1</a
                                        >
                                      </div>
                                      <!--caption a7-->
                                      <div class="caption">
                                        <p id="__p2">
                                          A: guanine quartet; B: antiparallel
                                          folding pattern for thrombin binding
                                          aptamer quadruplex determined by NMR
                                          <sup
                                            ><a rid="R8" class="bibr popnode"
                                              >8</a
                                            > </sup
                                          >; C: possible alternative
                                          antiparallel strand conformation; D:
                                          possible unimolecular parallel folding
                                          topology; E: possible bimolecular
                                          parallel folding topology. The
                                          5&#x02032;-end of the strand is
                                          indicated by the symbol &#x025cf;
                                          while the 3&#x02032; end is indicated
                                          by &#x025a0;; quartets are represented
                                          by dashed boxes
                                        </p>
                                      </div>
                                    </div>
                                  </div>
                                  <p id="P3">
                                    In general, quadruplexes can be formed from
                                    one, two or four strands. In the case of
                                    one-stranded, or unimolecular, quadruplexes,
                                    the strand must fold on itself several times
                                    in order to create the quartet core,
                                    consisting of four guanine-rich segments. In
                                    the vast majority of unimolecular
                                    quadruplexes investigated by high resolution
                                    NMR, their folding is mediated by simple
                                    hairpin-like loops that result in half of
                                    the guanine segments orientated antiparallel
                                    to the other half
                                    <sup
                                      ><a rid="R9" class="bibr popnode"
                                        >9</a
                                      > </sup
                                    >. The two principal folds consistent with
                                    this overall antiparallel configuration,
                                    characterized by a lateral or diagonal
                                    central loop, are illustrated in
                                    <a
                                      target="figure"
                                      class="fig-table-link figpopup"
                                      rid-figpopup="F1"
                                      rid-ob="ob-F1"
                                      co-legend-rid="lgnd_F1"
                                      ><span>Figure 1B,C</span> </a
                                    >. Both of these folds have in common the
                                    requirement that half the guanine
                                    nucleosides adopt the
                                    <em>syn</em> conformation about the
                                    glycoside bond, while the other half remain
                                    in the more common
                                    <em>anti</em> conformation.
                                  </p>
                                  <p id="P4">
                                    In addition to the antiparallel folding
                                    motif described above, more recent
                                    structural studies have revealed an
                                    all-parallel motif. One of the earliest such
                                    structures was described by Uesugi, Katahira
                                    and co-workers, using the sequence
                                    d(GGA)<sub>4</sub>
                                    <sup
                                      ><a
                                        rid="R10"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393611"
                                        >10</a
                                      > </sup
                                    >. This unusual structure involves a guanine
                                    quartet stacked on top of a GAGAGAG heptad.
                                    This structure is reminiscent of that
                                    described earlier for a two-stranded
                                    quadruplex formed by the sequence
                                    d((GGA)<sub>2</sub>G), i.e. a guanine
                                    quartet stacked on an AGGGGA hexad, with the
                                    two strands oriented parallel to each other
                                    <sup
                                      ><a
                                        rid="R11"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393614"
                                        >11</a
                                      > </sup
                                    >. More recently, a parallel, unimolecular
                                    quadruplex has been described in an X-ray
                                    crystal structure of the human telomere
                                    sequence
                                    d(AG<sub>3</sub>(TTAG<sub>3</sub>)<sub>3</sub>)
                                    in the presence of potassium ions
                                    <sup
                                      ><a
                                        rid="R12"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393620"
                                        >12</a
                                      > </sup
                                    >, also shown in
                                    <a
                                      target="figure"
                                      class="fig-table-link figpopup"
                                      rid-figpopup="F1"
                                      rid-ob="ob-F1"
                                      co-legend-rid="lgnd_F1"
                                      ><span>Figure 1D</span> </a
                                    >. This result was of particular interest in
                                    light of a previously reported solution
                                    structure for the same sequence in the
                                    presence of sodium ions that showed a more
                                    traditional antiparallel folding motif
                                    <sup
                                      ><a
                                        rid="R13"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393647"
                                        >13</a
                                      > </sup
                                    >. While some efforts at detecting a
                                    parallel quadruplex for this sequence in
                                    solution have been positive
                                    <sup
                                      ><a
                                        rid="R14"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393683"
                                        >14</a
                                      > </sup
                                    >, others have been negative
                                    <sup
                                      ><a rid="R15" class="bibr popnode"
                                        >15</a
                                      > </sup
                                    >. Other sequences have also revealed a
                                    parallel, unimolecular quadruplex
                                    conformation in solution, e.g. that from the
                                    <em>c-myc</em> promoter region
                                    <sup
                                      ><a
                                        rid="R16"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393646"
                                        >16</a
                                      >
                                    </sup>
                                    <sup>-</sup>
                                    <sup
                                      ><a
                                        rid="R18"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_542189905"
                                        >18</a
                                      > </sup
                                    >.
                                  </p>
                                  <p id="P5" class="p p-last">
                                    In light of these observations regarding the
                                    various folding topologies for unimolecular
                                    quadruplexes, it is of interest to assess
                                    the factors that determine whether a given
                                    sequence will fold in an antiparallel or
                                    parallel fashion. We approach this question
                                    here by examining the effect of
                                    <em>syn/anti</em> preferences of individual
                                    guanine nucleosides on the overall fold,
                                    using site-specific substitution of
                                    deoxyribonucleosides, dG&#x02019;s, with
                                    ribonucleosides, rG&#x02019;s. It is well
                                    known that in oligo- and polynucleotides, dG
                                    has a significantly greater propensity for
                                    the <em>syn</em> conformation than does rG
                                    <sup
                                      ><a rid="R19" class="bibr popnode"
                                        >19</a
                                      > </sup
                                    >. In the case of polynucleotides, for
                                    example, it is more difficult to induce the
                                    Z-form, left-handed conformation in
                                    poly(rG-rC)&#x000b7;poly(rG-rC) than in
                                    poly(dG-dC)&#x000b7;poly(dG-dC)
                                    <sup
                                      ><a
                                        rid="R20"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393623"
                                        >20</a
                                      > </sup
                                    >, which can be attributed, at least in
                                    part, to the higher energy of the
                                    <em>syn</em> conformation in RNA compared to
                                    DNA in the context of double helical
                                    structures.
                                  </p>
                                </div>
                                <div id="S2" class="tsec sec">
                                  <h2
                                    class="head no_bottom_margin"
                                    id="S2title"
                                  >
                                    Experimental Procedures
                                  </h2>
                                  <div id="S3" class="sec sec-first">
                                    <h3 id="S3title">Oligonucleotides</h3>
                                    <p id="P6" class="p p-first">
                                      All oligonucleotides were purchased from
                                      IDT (Coralville, IA) with ion-exchange
                                      HPLC purification, and are based on the
                                      15-mer sequence of the thrombin binding
                                      aptamer,
                                      <strong>dTBA</strong>, as listed in
                                      <a
                                        target="table"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="T1"
                                        rid-ob="ob-T1"
                                        co-legend-rid=""
                                        ><span>Table 1</span> </a
                                      >. Concentrations were determined
                                      spectrophotometrically, using the
                                      extinction coefficients listed in
                                      <a
                                        target="table"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="T1"
                                        rid-ob="ob-T1"
                                        co-legend-rid=""
                                        ><span>Table 1</span>
                                      </a>
                                    </p>
                                    <!--table ft1--><!--table-wrap mode="anchored" t5-->
                                    <div
                                      class="table-wrap table anchored whole_rhythm"
                                      id="T1"
                                    >
                                      <h3>Table 1</h3>
                                      <!--caption a7-->
                                      <div class="caption">
                                        <p id="__p7">
                                          Oligonucleotide sequences used in this
                                          study and their extinction
                                          coefficients
                                        </p>
                                      </div>
                                      <div
                                        data-largeobj=""
                                        data-largeobj-link-rid="largeobj_idm139857528344896"
                                        class="xtable"
                                      >
                                        <table
                                          frame="above"
                                          rules="groups"
                                          class="rendered small default_table"
                                        >
                                          <thead>
                                            <tr>
                                              <th
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                Oligonucleotide
                                              </th>
                                              <th
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                Sequence<sup>a</sup>
                                              </th>
                                              <th
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                &#x003b5;<sub>260</sub>
                                                <sup>b</sup>, L (mol strand)<sup
                                                  >-1</sup
                                                >
                                                cm<sup>-1</sup>
                                              </th>
                                            </tr>
                                          </thead>
                                          <tbody>
                                            <tr>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBA</strong>
                                              </td>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                5&#x02032;-<span
                                                  class="underline"
                                                  >G</span
                                                >GTT<span class="underline"
                                                  >G</span
                                                >GTGT<span class="underline"
                                                  >G</span
                                                >GTT<span class="underline"
                                                  >G</span
                                                >G-3&#x02032;
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                147,920
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBAr1</strong>
                                              </td>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                5&#x02032;-<span
                                                  class="underline"
                                                  >g</span
                                                >GTT<span class="underline"
                                                  >g</span
                                                >GTGT<span class="underline"
                                                  >g</span
                                                >GTT<span class="underline"
                                                  >g</span
                                                >G-3&#x02032;
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                150,020
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBAr2</strong>
                                              </td>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                5&#x02032;-<span
                                                  class="underline"
                                                  >G</span
                                                >gTT<span class="underline"
                                                  >G</span
                                                >gTGT<span class="underline"
                                                  >G</span
                                                >gTT<span class="underline"
                                                  >G</span
                                                >g-3&#x02032;
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                150,140
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>rTBA</strong>
                                              </td>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                5&#x02032;-<span
                                                  class="underline"
                                                  >g</span
                                                >guu<span class="underline"
                                                  >g</span
                                                >gugu<span class="underline"
                                                  >g</span
                                                >guu<span class="underline"
                                                  >g</span
                                                >g-3&#x02032;
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                156,380
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>rTBAd1</strong>
                                              </td>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                5&#x02032;-<span
                                                  class="underline"
                                                  >G</span
                                                >guu<span class="underline"
                                                  >G</span
                                                >gugu<span class="underline"
                                                  >G</span
                                                >guu<span class="underline"
                                                  >G</span
                                                >g-3&#x02032;
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                154,280
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBAr2</strong>
                                              </td>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                5&#x02032;-<span
                                                  class="underline"
                                                  >g</span
                                                >Guu<span class="underline"
                                                  >g</span
                                                >Gugu<span class="underline"
                                                  >g</span
                                                >Guu<span class="underline"
                                                  >g</span
                                                >G-3&#x02032;
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                154,160
                                              </td>
                                            </tr>
                                          </tbody>
                                        </table>
                                      </div>
                                      <div
                                        id="largeobj_idm139857528344896"
                                        class="largeobj-link align_right"
                                        style="display: none"
                                      >
                                        <a target="object"
                                          >Open in a separate window</a
                                        >
                                      </div>
                                      <div class="tblwrap-foot">
                                        <div id="TFN1">
                                          <sup>a</sup>Ribonucleosides appear in
                                          lower case, deoxyribonucleosides in
                                          upper case.
                                        </div>
                                        <div id="TFN2">
                                          <sup>b</sup>Calculated according to
                                          Gray et al.
                                          <sup
                                            ><a
                                              rid="R21"
                                              class="bibr popnode tag_hotlink tag_tooltip"
                                              id="__tag_160393613"
                                              >21</a
                                            >
                                          </sup>
                                        </div>
                                      </div>
                                    </div>
                                    <p id="P7" class="p p-last">
                                      The notation used in
                                      <a
                                        target="table"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="T1"
                                        rid-ob="ob-T1"
                                        co-legend-rid=""
                                        ><span>Table 1</span>
                                      </a>
                                      is as follows: ribonucleosides appear in
                                      lower case while deoxyribonucleosides
                                      appear in upper case. Positions that are
                                      underlined represent those nucleosides
                                      which possess the
                                      <em>syn</em> conformation about the
                                      glycosidic bond in the unimolecular
                                      quadruplex formed by the DNA thrombin
                                      binding aptamer, denoted here as
                                      <strong>dTBA</strong>
                                      <sup
                                        ><a rid="R8" class="bibr popnode"
                                          >8</a
                                        > </sup
                                      >. Sequences whose names start with the
                                      letter &#x0201c;d&#x0201d; are completely,
                                      or primarily, composed of
                                      deoxyribonucleosides, whereas those
                                      starting with the letter
                                      &#x0201c;r&#x0201d; are all, or mainly,
                                      composed of ribonucleosides. Thus
                                      <strong>dTBA</strong> consists entirely of
                                      deoxyribonucleosides while
                                      <strong>rTBA</strong> consists entirely of
                                      ribonucleosides; all remaining sequences
                                      are chimeric, containing both ribo- and
                                      deoxyribonucleosides.
                                    </p>
                                  </div>
                                  <div id="S4" class="sec">
                                    <h3 id="S4title">Spectrophotometry</h3>
                                    <p id="P8" class="p p-first-last">
                                      Oligonucleotides were annealed by heating
                                      samples to 90 &#x000b0;C for 5 min, then
                                      cooling slowly to 15 &#x000b0;C in 10 mM
                                      Li-cacodylate buffer, pH 6.8, and with the
                                      addition of 25 mM KCl as indicated. CD
                                      experiments were carried out on an Aviv
                                      215 Circular Dichroism spectrophotometer
                                      equipped with a peltier temperature
                                      controller. All CD spectral scans were
                                      accumulated over the wavelength range
                                      220-350 nm at 15 &#x000b0;C, unless
                                      otherwise noted. The scan of buffer alone
                                      was subtracted from each sample. Both CD
                                      and UV measurements on concentrated
                                      samples were made in 0.1 cm path-length
                                      cells. UV melting curves were measured in
                                      a Cary 100 spectrophotometer equipped with
                                      a peltier heating device and run at a
                                      heating rate of 0.2 &#x000b0;C/min.
                                      Thermodynamic analysis was carried out
                                      with an all-or-none model for quadruplex
                                      unfolding, assuming
                                      temperature-independent enthalpy and
                                      entropy changes.
                                    </p>
                                  </div>
                                  <div id="S5" class="sec">
                                    <h3 id="S5title">
                                      Nondenaturing polyacrylamide gel
                                      electrophoresis (PAGE)
                                    </h3>
                                    <p id="P9" class="p p-first-last">
                                      Oligonucleotides, at a concentration of 80
                                      &#x003bc;M strand, were heated in 10 mM
                                      Tris acetate, pH 6.8, and 25 mM KCl for 1
                                      min at 90 &#x000b0;C, then slowly cooled
                                      to room temperature. Samples were then run
                                      on a 10 cm &#x000d7; 10 cm, 20%
                                      polyacrylamide (19:1
                                      acrylamide:bisacrylamide ratio)
                                      nondenaturing gel, made up in 40 mM
                                      Tris-acetate buffer containing 25 mM KCl
                                      (also used for the running buffer) for 2.5
                                      hours at 240V in a cold room at 4
                                      &#x000b0;C. Gels were stained with
                                      stains-all and destained in 70% ethanol.
                                    </p>
                                  </div>
                                  <div id="S6" class="sec sec-last">
                                    <h3 id="S6title">1D imino proton NMR</h3>
                                    <p id="P10" class="p p-first-last">
                                      NMR spectra were obtained on a Varian 600
                                      MHz NMR instrument with a watergate pulse
                                      <sup
                                        ><a
                                          rid="R22"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393686"
                                          >22</a
                                        >
                                      </sup>
                                      for solvent suppression. Samples (500
                                      &#x003bc;M strand) were prepared in 90 %
                                      H<sub>2</sub>O/10 %
                                      <sup>2</sup>H<sub>2</sub>O in the presence
                                      of 25 mM KCl and 10 mM perdeuterated
                                      Tris-acetate, pH 6.8.
                                    </p>
                                  </div>
                                </div>
                                <div id="S7" class="tsec sec">
                                  <h2
                                    class="head no_bottom_margin"
                                    id="S7title"
                                  >
                                    Results
                                  </h2>
                                  <div id="S8" class="sec sec-first">
                                    <h3 id="S8title">Circular Dichroism</h3>
                                    <p id="P11" class="p p-first">
                                      Circular dichroism (CD) spectra can be
                                      used to assess the nature of the
                                      quadruplex fold, based on observations
                                      that antiparallel quadruplexes present a
                                      long-wavelength positive maximum near 293
                                      nm in the presence of sodium or potassium,
                                      while parallel quadruplexes exhibit a CD
                                      maximum near 265 nm
                                      <sup
                                        ><a
                                          rid="R23"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393655"
                                          >23</a
                                        > </sup
                                      >. This difference has been attributed to
                                      the requirement for half of the
                                      deoxyguanosine nucleosides to possess the
                                      <em>syn</em> conformation about the
                                      glycosidic bond in order to fully realize
                                      the hydrogen bonding pattern of the
                                      guanine quartet, illustrated in
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F1"
                                        rid-ob="ob-F1"
                                        co-legend-rid="lgnd_F1"
                                        ><span>Figure 1A</span>
                                      </a>
                                      <sup
                                        ><a
                                          rid="R24"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393685"
                                          >24</a
                                        > </sup
                                      >. Although the use of CD to distinguish
                                      parallel from antiparallel folding
                                      topologies has proved to be reliable in
                                      general, some have suggested that it may
                                      not always lead to the correct or expected
                                      result
                                      <sup
                                        ><a
                                          rid="R25"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393624"
                                          >25</a
                                        >
                                      </sup>
                                      <sup>, </sup>
                                      <sup
                                        ><a
                                          rid="R26"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393631"
                                          >26</a
                                        > </sup
                                      >. Nonetheless, the vast majority of
                                      published reports are consistent with
                                      these observations; for example, we are
                                      aware of no instance of a known parallel
                                      quadruplex with a single, positive peak
                                      near 293 nm. Thus we are confident that
                                      the very distinct spectra described below
                                      can be used to discriminate between
                                      parallel and antiparallel quadruplex
                                      structures.
                                    </p>
                                    <p id="P12">
                                      In
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F2"
                                        rid-ob="ob-F2"
                                        co-legend-rid="lgnd_F2"
                                        ><span>Figure 2A</span> </a
                                      >, we present CD spectra for the thrombin
                                      binding aptamer, <strong>dTBA</strong>.
                                      The spectrum in the presence of buffer
                                      alone shows several low-amplitude bands
                                      indicative of a relatively unstructured
                                      state, and similar to what we have
                                      reported earlier in the absence of added
                                      metal ions
                                      <sup
                                        ><a
                                          rid="R27"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393635"
                                          >27</a
                                        > </sup
                                      >. Addition of 25 mM KCl results in a
                                      dramatic overall change in the CD
                                      spectrum, with a large positive maximum
                                      near 293 nm, characteristic of
                                      antiparallel quadruplex structures, in
                                      this case an antiparallel, unimolecular
                                      folded quadruplex. The high resolution NMR
                                      structure of this sequence stabilized by
                                      K<sup>+</sup> reveals the overall fold to
                                      be that shown in
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F1"
                                        rid-ob="ob-F1"
                                        co-legend-rid="lgnd_F1"
                                        ><span>Figure 1B</span>
                                      </a>
                                      and also establishes that half of the
                                      deoxyguanosines are in the
                                      <em>syn</em> conformation
                                      <sup
                                        ><a rid="R8" class="bibr popnode"
                                          >8</a
                                        > </sup
                                      >. Similar observations have been reported
                                      for all other quadruplexes involving
                                      antiparallel folds, including both
                                      unimolecular and bimolecular constructs
                                      <sup
                                        ><a rid="R9" class="bibr popnode"
                                          >9</a
                                        > </sup
                                      >.
                                    </p>
                                    <!--fig ft0--><!--fig mode=article f1-->
                                    <div
                                      class="fig iconblock whole_rhythm clearfix"
                                      id="F2"
                                      co-legend-rid="lgnd_F2"
                                    >
                                      <a
                                        target="figure"
                                        rid-figpopup="F2"
                                        rid-ob="ob-F2"
                                        ><!--fig/graphic|fig/alternatives/graphic mode="anchored" m1-->
                                        <div
                                          data-largeobj=""
                                          data-largeobj-link-rid="largeobj_idm139857561655616"
                                          class="figure"
                                        >
                                          <img
                                            class="fig-image"
                                            alt="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0002.jpg"
                                            title="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0002.jpg"
                                            src="http://img.staging.deepbiogroup.com/AptamerImageTotals/774568600001.jpg"
                                          />
                                        </div>
                                        <div
                                          id="largeobj_idm139857561655616"
                                          class="largeobj-link align_right"
                                          style="display: none"
                                        >
                                          <a target="object"
                                            >Open in a separate window</a
                                          >
                                        </div>
                                      </a>
                                      <div class="icnblk_cntnt" id="lgnd_F2">
                                        <div>
                                          <a
                                            class="figpopup"
                                            target="figure"
                                            rid-figpopup="F2"
                                            rid-ob="ob-F2"
                                            >Figure 2</a
                                          >
                                        </div>
                                        <!--caption a7-->
                                        <div class="caption">
                                          <p id="__p3">
                                            CD spectra for various sequences,
                                            measured at a concentration of 7
                                            &#x003bc;M in 10 mM Li-cacodylate at
                                            15 &#x000b0;C in 1 cm path cells,
                                            unless otherwise specified. A:
                                            <strong>dTBA</strong> in buffer
                                            alone (&#x02014;&#x02014;) or with
                                            25 mM KCl (&#x025cf;); B:
                                            <strong>rTBA</strong> in buffer
                                            alone (&#x02014;&#x02014;) or with
                                            25 mM KCl (&#x025cf;); C:
                                            <strong>dTBAr1</strong>, in buffer
                                            with 25 mM KCl, 5 &#x000b0;C,
                                            measured at 60 &#x003bc;M in a 0.1
                                            cm cell; (&#x025cb;),
                                            <strong>dTBAr2</strong> in buffer
                                            with 25 mM KCl (&#x025cf;); D:
                                            <strong>rTBAd1</strong> in buffer
                                            with 25 mM KCl (&#x025cf;),
                                            <strong>rTBAd2</strong> in buffer
                                            with 25 m M KCl (&#x025cb;).
                                          </p>
                                        </div>
                                      </div>
                                    </div>
                                    <p id="P13">
                                      When the same experiment is carried out
                                      with the all-RNA analog,
                                      <strong>rTBA</strong>, the CD spectrum in
                                      the absence of added metal ion resembles
                                      that of <strong>dTBA</strong>, consisting
                                      of very low amplitude features
                                      characteristic of a minimally structured
                                      state (<a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F2"
                                        rid-ob="ob-F2"
                                        co-legend-rid="lgnd_F2"
                                        ><span>Figure 2B</span> </a
                                      >). The addition of KCl (25 mM) results
                                      again in a change in the CD spectrum, but
                                      to a significantly different pattern. Most
                                      importantly, the long-wavelength maximum
                                      is shifted to 265 nm, characteristic of
                                      parallel quadruplex structures. This
                                      spectrum, consisting of a single positive
                                      peak, is clearly distinct from that of
                                      <strong>dTBA</strong> and indicates a
                                      major change in overall structure for
                                      <strong>rTBA</strong>. In particular, a
                                      parallel quadruplex conformation implies
                                      that all nucleosides are in the
                                      <em>anti</em> conformation, demonstrating
                                      that replacement of all
                                      deoxyribonucleosides with their
                                      corresponding ribonucleosides results in a
                                      refolding of the antiparallel structure to
                                      a parallel structure.
                                    </p>
                                    <p id="P14">
                                      We next made more selective substitutions
                                      of ribo- for deoxyribonucleosides. Our
                                      rationale was based on the well known
                                      observation that ribonucleosides strongly
                                      prefer the
                                      <em>anti</em> conformation about the
                                      glycosidic bond to the
                                      <em>syn</em> conformation, as mentioned
                                      above. Thus selective substitution of the
                                      dG nucleosides in
                                      <strong>dTBA</strong> that possess the
                                      <em>syn</em> conformation about the
                                      glycosidic bond may significantly
                                      destabilize the antiparallel fold,
                                      possibly leading to a parallel fold.
                                    </p>
                                    <p id="P15">
                                      The NMR solution structures for
                                      <strong>dTBA</strong> reveal that dG
                                      nucleosides in positions 1, 5, 10, and 14
                                      all possess the <em>syn</em> conformation
                                      <sup
                                        ><a rid="R8" class="bibr popnode"
                                          >8</a
                                        > </sup
                                      >. Thus we substituted just those
                                      positions with rG nucleosides, leading to
                                      the oligonucleotide
                                      <strong>dTBAr1</strong>. For this
                                      sequence, addition of KCl to buffer
                                      results in a positive CD peak at 265 nm,
                                      similar to that of the all-RNA sequence
                                      <strong>rTBA</strong>, as illustrated in
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F2"
                                        rid-ob="ob-F2"
                                        co-legend-rid="lgnd_F2"
                                        ><span>Figure 2C</span> </a
                                      >. This result is fully consistent with
                                      our predictions, based on the observation
                                      that ribonucleosides strongly prefer the
                                      <em>anti</em> over the
                                      <em>syn</em> conformation when
                                      incorporated in oligo- or polynucleotides.
                                      This spectrum was obtained at relatively
                                      high strand concentration (and low
                                      temperature); CD spectra obtained under
                                      standard conditions showed little
                                      difference from those observed in buffer
                                      alone. This concentration dependence
                                      suggests the possibility that the
                                      quadruplex formed by the chimeric
                                      <strong>dTBAr1</strong> sequence may
                                      consist of more than one strand. This
                                      possibility is investigated further below.
                                    </p>
                                    <p id="P16">
                                      As an additional test of our hypothesis
                                      that the <em>syn-anti</em> behavior of
                                      individual nucleosides plays a major role
                                      in affecting the overall quadruplex fold,
                                      we examined a control sequence,
                                      <strong>dTBAr2</strong>, in which the
                                      other four dG residues (those which
                                      possess the <em>anti</em> conformation in
                                      the antiparallel quadruplex formed by
                                      <strong>dTBA</strong>) have been replaced
                                      by rG. Here we expected little or no
                                      difference compared to
                                      <strong>dTBA</strong> and indeed this
                                      turns out to be the case, as illustrated
                                      in
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F2"
                                        rid-ob="ob-F2"
                                        co-legend-rid="lgnd_F2"
                                        ><span>Figure 2C</span> </a
                                      >, where it can be seen that
                                      <strong>dTBAr2</strong> exhibits a
                                      positive CD peak at 293 nm, consistent
                                      with an antiparallel fold.
                                    </p>
                                    <p id="P17">
                                      Having converted the antiparallel fold of
                                      <strong>dTBA</strong> to a parallel fold
                                      by selective substitution of rG for dG, we
                                      turned to the converse, i.e. converting
                                      the parallel fold of
                                      <strong>rTBA</strong> to an antiparallel
                                      fold. Thus we investigated the properties
                                      of <strong>rTBAd1</strong>, in which the
                                      rG nucleosides at positions 1, 5, 10 and
                                      14 are substituted by dG. Here we have
                                      selectively replaced syn-phobic
                                      nucleosides with syn-philic ones and now
                                      this chimeric sequence folds into an
                                      antiparallel quadruplex, as demonstrated
                                      by its CD spectrum shown in
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F2"
                                        rid-ob="ob-F2"
                                        co-legend-rid="lgnd_F2"
                                        ><span>Figure 2D</span> </a
                                      >. Again, replacing the other rG
                                      nucleosides with dG, to yield
                                      <strong>rTBAd2,</strong> the relevant
                                      control sequence, leads to a parallel
                                      quadruplex fold, similar to its parent
                                      sequence <strong>rTBA</strong>, also shown
                                      in
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F2"
                                        rid-ob="ob-F2"
                                        co-legend-rid="lgnd_F2"
                                        ><span>Figure 2D</span> </a
                                      >.
                                    </p>
                                    <p id="P18" class="p p-last">
                                      We have repeated these CD spectra in the
                                      presence of 100 mM NaCl instead of 25 mM
                                      KCl. For
                                      <strong>dTBA, rTBA, dTBAr2</strong>, and
                                      <strong>rTBAd1</strong>, the spectra
                                      observed in NaCl are similar to those
                                      observed in KCl, except with smaller
                                      amplitudes (data not shown). In the case
                                      of <strong>dTBAr1</strong> and
                                      <strong>rTBAd2</strong>, addition of NaCl
                                      led to little or no change compared to
                                      buffer alone, indicating no quadruplex
                                      formation, most likely due to the
                                      extremely weak strand association for
                                      these sequences under these conditions
                                      (see below).
                                    </p>
                                  </div>
                                  <div id="S9" class="sec">
                                    <h3 id="S9title">
                                      Polyacrylamide gel electrophoresis
                                    </h3>
                                    <p id="P19" class="p p-first-last">
                                      In order to further examine the
                                      possibility that some of the species
                                      considered here consist of more than one
                                      strand, we carried out native
                                      polyacrylamide gel electrophoresis. In
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F3"
                                        rid-ob="ob-F3"
                                        co-legend-rid="lgnd_F3"
                                        ><span>Figure 3</span> </a
                                      >, it is apparent that the sequences which
                                      exhibit positive CD peaks at 293 nm
                                      (<strong>dTBA, dTBAr2</strong>, and
                                      <strong>rTBAd1</strong>) exhibit higher
                                      electrophoretic mobility in comparison to
                                      those sequences possessing a CD peak at
                                      265 nm (<strong>rTBA, rTBAd2</strong> and
                                      <strong>dTBAr1</strong>). The position of
                                      the slower-moving bands, near the gel
                                      position for the 20- and 27-mer components
                                      of the ladder, suggests that these
                                      structures are composed of more than one
                                      strand, and are most likely two-stranded
                                      rather than four-stranded species; the
                                      latter would be expected to migrate even
                                      more slowly in the gel. There is evidence
                                      for some minor species in some of the
                                      lanes, which could represent small amounts
                                      of impurities or a small population of
                                      unfolded or differently folded
                                      oligonucleotide. In this regard, we note
                                      that these samples were run at relatively
                                      high concentration in order to facilitate
                                      the formation of any two-stranded
                                      structures. Nonetheless, the positions of
                                      the major species are clear, and indicate
                                      a unimolecular fold for the antiparallel
                                      structures and a bimolecular fold for the
                                      parallel structures.
                                    </p>
                                    <!--fig ft0--><!--fig mode=article f1-->
                                    <div
                                      class="fig iconblock whole_rhythm clearfix"
                                      id="F3"
                                      co-legend-rid="lgnd_F3"
                                    >
                                      <a
                                        target="figure"
                                        rid-figpopup="F3"
                                        rid-ob="ob-F3"
                                        ><!--fig/graphic|fig/alternatives/graphic mode="anchored" m1-->
                                        <div
                                          data-largeobj=""
                                          data-largeobj-link-rid="largeobj_idm139857512083776"
                                          class="figure"
                                        >
                                          <img
                                            class="fig-image"
                                            alt="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0003.jpg"
                                            title="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0003.jpg"
                                            src="http://img.staging.deepbiogroup.com/AptamerImageTotals/774568600002.jpg"
                                          />
                                        </div>
                                        <div
                                          id="largeobj_idm139857512083776"
                                          class="largeobj-link align_right"
                                          style="display: none"
                                        >
                                          <a target="object"
                                            >Open in a separate window</a
                                          >
                                        </div>
                                      </a>
                                      <div class="icnblk_cntnt" id="lgnd_F3">
                                        <div>
                                          <a
                                            class="figpopup"
                                            target="figure"
                                            rid-figpopup="F3"
                                            rid-ob="ob-F3"
                                            >Figure 3</a
                                          >
                                        </div>
                                        <!--caption a7-->
                                        <div class="caption">
                                          <p id="__p4">
                                            Non-denaturing polyacrylamide gel
                                            run at 4 &#x000b0;C. Lanes 1 - 7:
                                            <strong>dTBAr2, dTBAr1, dTBA</strong
                                            >, DNA ladder (dT<sub>10</sub>,
                                            dT<sub>15</sub>, dT<sub>20</sub>,
                                            dT<sub>27</sub>),
                                            <strong>rTBA, rTBAd1, rTBAd2</strong
                                            >, respectively.
                                          </p>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                  <div id="S10" class="sec">
                                    <h3 id="S10title">
                                      Thermal denaturation studies
                                    </h3>
                                    <p id="P20" class="p p-first">
                                      The molecularity of these quadruplex
                                      structures can be further investigated by
                                      examining the concentration dependence of
                                      the melting temperature, assessed by
                                      finding the temperature, T<sub>max</sub>,
                                      corresponding to the maximum in the slope
                                      of the melting curve. This measure of
                                      thermal stability does not require any
                                      modeling or assumption of molecularity and
                                      thus is useful when the latter is in
                                      doubt. UV melting curves were measured for
                                      each of these sequences.
                                    </p>
                                    <p id="P21">
                                      The effect of strand concentration on the
                                      melting temperature for
                                      <strong>dTBA, rTBA</strong> and
                                      <strong>rTBAd1</strong> is summarized in
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F4"
                                        rid-ob="ob-F4"
                                        co-legend-rid="lgnd_F4"
                                        ><span>Figure 4</span> </a
                                      >, where it can be seen that the T<sub
                                        >max</sub
                                      >
                                      of the all-RNA sequence,
                                      <strong>rTBA</strong>, exhibits
                                      significant concentration dependence while
                                      that of the other two sequences appears
                                      independent of strand concentration. Among
                                      these three sequences, only
                                      <strong>rTBA</strong> exhibited a
                                      substantial hysteresis and a biphasic
                                      character in its melting profile. In such
                                      cases, the T<sub>max</sub>
                                      was determined for the first transition in
                                      the heating direction. Similar behavior
                                      has been reported for this sequence by
                                      others
                                      <sup
                                        ><a
                                          rid="R28"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393630"
                                          >28</a
                                        > </sup
                                      >. While this suggests a more complicated
                                      set of conformations for this sequence and
                                      possible kinetic issues, rendering
                                      thermodynamic analysis difficult, the
                                      strand concentration dependence is
                                      nonetheless apparent. The two antiparallel
                                      structures, <strong>dTBA</strong> and
                                      <strong>rTBAd1</strong>, do not exhibit a
                                      concentration-dependent T<sub>max</sub>
                                      and hence behave as unimolecular species,
                                      consistent with their high gel mobilities.
                                      In contrast, both gel behavior and
                                      concentration dependence of melting
                                      temperature support a two-stranded species
                                      for the parallel quadruplexes in this
                                      study.
                                    </p>
                                    <!--fig ft0--><!--fig mode=article f1-->
                                    <div
                                      class="fig iconblock whole_rhythm clearfix"
                                      id="F4"
                                      co-legend-rid="lgnd_F4"
                                    >
                                      <a
                                        target="figure"
                                        rid-figpopup="F4"
                                        rid-ob="ob-F4"
                                        ><!--fig/graphic|fig/alternatives/graphic mode="anchored" m1-->
                                        <div
                                          data-largeobj=""
                                          data-largeobj-link-rid="largeobj_idm139857525740912"
                                          class="figure"
                                        >
                                          <img
                                            class="fig-image"
                                            alt="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0004.jpg"
                                            title="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0004.jpg"
                                            src="http://img.staging.deepbiogroup.com/AptamerImageTotals/774568600003.jpg"
                                          />
                                        </div>
                                        <div
                                          id="largeobj_idm139857525740912"
                                          class="largeobj-link align_right"
                                          style="display: none"
                                        >
                                          <a target="object"
                                            >Open in a separate window</a
                                          >
                                        </div>
                                      </a>
                                      <div class="icnblk_cntnt" id="lgnd_F4">
                                        <div>
                                          <a
                                            class="figpopup"
                                            target="figure"
                                            rid-figpopup="F4"
                                            rid-ob="ob-F4"
                                            >Figure 4</a
                                          >
                                        </div>
                                        <!--caption a7-->
                                        <div class="caption">
                                          <p id="__p5">
                                            Thermal denaturation temperature,
                                            T<sub>max</sub>, as a function of
                                            strand concentration for dTBA
                                            (&#x025cb;), rTBAd1 (&#x025a0;) and
                                            rTBA (&#x025cf;). Melting curves
                                            were determined in 10 mM
                                            Li-cacodylate buffer, pH 6.8,
                                            containing 25 mM KCl. Straight lines
                                            represent least-squares fit to the
                                            data points.
                                          </p>
                                        </div>
                                      </div>
                                    </div>
                                    <p id="P22">
                                      Results for T<sub>max</sub> values are
                                      presented in
                                      <a
                                        target="table"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="T2"
                                        rid-ob="ob-T2"
                                        co-legend-rid=""
                                        ><span>Table 2</span> </a
                                      >. The all-DNA sequence,
                                      <strong>dTBA</strong>, melts at 46
                                      &#x000b0;C, in excellent agreement with
                                      our earlier work on this sequence under
                                      similar conditions
                                      <sup
                                        ><a
                                          rid="R29"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393616"
                                          >29</a
                                        > </sup
                                      >. As this sequence folds into a
                                      unimolecular quadruplex, its melting
                                      temperature is independent of strand
                                      concentration. In the case of the parallel
                                      structures, however, specifying a melting
                                      temperature is more ambiguous, as one must
                                      also specify strand concentration.
                                      Nonetheless, at relatively high strand
                                      concentration,
                                      <strong>dTBAr1</strong> exhibits the
                                      lowest T<sub>max</sub>, and hence has the
                                      lowest thermal stability overall. For
                                      other parallel quadruplex structures,
                                      <strong>rTBA,</strong> at high strand
                                      concentration, exhibits a melting
                                      temperature similar to that of
                                      <strong>dTBA</strong> but a melting
                                      temperature about 5 &#x000b0;C lower than
                                      <strong>dTBA</strong> measured at low
                                      strand concentration, while
                                      <strong>rTBAd2</strong> melts at a fairly
                                      low temperature, 29 &#x000b0;C, at low
                                      strand concentration. These results are
                                      consistent with the need to measure the CD
                                      spectrum of <strong>dTBAr1</strong> at low
                                      temperature and high strand concentration.
                                      Similarly, they are consistent with the
                                      lack of quadruplex formation by
                                      <strong>dTBAr1</strong> and
                                      <strong>rTBAd2</strong> in NaCl solution,
                                      as these two sequences form the least
                                      stable quadruplexes in KCl.
                                    </p>
                                    <!--table ft1--><!--table-wrap mode="anchored" t5-->
                                    <div
                                      class="table-wrap table anchored whole_rhythm"
                                      id="T2"
                                    >
                                      <h3>Table 2</h3>
                                      <!--caption a7-->
                                      <div class="caption">
                                        <p id="__p8">
                                          Melting temperatures determined by UV
                                          thermal denaturation<sup>a</sup>
                                        </p>
                                      </div>
                                      <div
                                        data-largeobj=""
                                        data-largeobj-link-rid="largeobj_idm139857513470576"
                                        class="xtable"
                                      >
                                        <table
                                          frame="hsides"
                                          rules="groups"
                                          class="rendered small default_table"
                                        >
                                          <thead>
                                            <tr>
                                              <th
                                                align="left"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                Sequence
                                              </th>
                                              <th
                                                align="center"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                T<sub>max</sub>, &#x000b0;C
                                              </th>
                                            </tr>
                                          </thead>
                                          <tbody>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBA</strong>
                                              </td>
                                              <td
                                                align="center"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                46
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBAr1</strong> (80
                                                &#x003bc;M)
                                              </td>
                                              <td
                                                align="center"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                22
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBAr2</strong>
                                              </td>
                                              <td
                                                align="center"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                52
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>rTBA</strong>
                                              </td>
                                              <td
                                                align="center"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                41
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>rTBAd1</strong>
                                              </td>
                                              <td
                                                align="center"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                49
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>rTBAd2</strong>
                                              </td>
                                              <td
                                                align="center"
                                                valign="top"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                29
                                              </td>
                                            </tr>
                                          </tbody>
                                        </table>
                                      </div>
                                      <div
                                        id="largeobj_idm139857513470576"
                                        class="largeobj-link align_right"
                                        style="display: none"
                                      >
                                        <a target="object"
                                          >Open in a separate window</a
                                        >
                                      </div>
                                      <div class="tblwrap-foot">
                                        <div id="TFN3">
                                          <sup>a</sup>Samples run in 10 mM
                                          Li-cacodylate buffer, pH 6.8
                                          containing 25 mM KCl and at 7
                                          &#x003bc;M strand concentration unless
                                          otherwise specified.
                                        </div>
                                      </div>
                                    </div>
                                    <p id="P23">
                                      In the case of the remaining, unimolecular
                                      antiparallel quadruplexes,
                                      <strong>dTBAr2</strong> and
                                      <strong>rTBAd1</strong>, both exhibit
                                      higher T<sub>max</sub> values than
                                      <strong>dTBA</strong>. This leads to the
                                      general observation that all antiparallel
                                      quadruplexes have higher melting
                                      temperatures than all of the parallel
                                      quadruplexes, indicating that, at least
                                      for this base sequence, the parallel
                                      folding topology is less thermally stable
                                      than the antiparallel topology.
                                      Furthermore, among the three antiparallel
                                      structures, the all-DNA sequence is the
                                      least stable, while among the three
                                      parallel structures, the all-RNA sequence
                                      is the most stable.
                                    </p>
                                    <p id="P24" class="p p-last">
                                      Results from thermodynamic analysis of the
                                      UV melting curves for those sequences
                                      forming unimolecular antiparallel
                                      quadruplexes are presented in
                                      <a
                                        target="table"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="T3"
                                        rid-ob="ob-T3"
                                        co-legend-rid=""
                                        ><span>Table 3</span> </a
                                      >. Similar analysis for parallel-forming
                                      species was not carried out due to
                                      significant hysteresis in their heating
                                      and cooling curves. In terms of thermal
                                      stability, the all-DNA sequence is the
                                      least stable while the mainly DNA
                                      sequence, <strong>dTBAr2</strong>, is the
                                      most stable. The intermediate thermal
                                      stability of the mainly RNA sequence,
                                      <strong>rTBAd1</strong>, suggests that RNA
                                      can essentially fold in a manner similar
                                      to that of its DNA analog when the barrier
                                      to taking on the <em>syn</em> conformation
                                      is removed. Both RNA-containing sequences
                                      in
                                      <a
                                        target="table"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="T3"
                                        rid-ob="ob-T3"
                                        co-legend-rid=""
                                        ><span>Table 3</span>
                                      </a>
                                      appear to have greater enthalpic
                                      contributions to the stability of their
                                      folded structures. This may be due to
                                      stacking differences and or other specific
                                      effects. The slightly lower thermal
                                      stability of
                                      <strong>rTBAd1</strong> compared to
                                      <strong>dTBAr2</strong> derives from
                                      destabilizing entropic effects which more
                                      than compensate the slight enthalpic
                                      preference for the former. Since
                                      differences in these terms are small, it
                                      is difficult to assess their real
                                      significance. What does appear unambiguous
                                      is that both RNA-containing sequences are
                                      more stable than the all-DNA sequence, and
                                      that this stability increase is enthalpic
                                      in nature. This larger enthalpy change for
                                      folding may arise from differences in
                                      direct structural features such as
                                      stacking and/or sugar pucker, the
                                      presence/absence of a 5-methyl group on
                                      T/U or other features, such as hydration.
                                      Additional studies will be necessary to
                                      determine the source of these enthalpy
                                      differences.
                                    </p>
                                    <!--table ft1--><!--table-wrap mode="anchored" t5-->
                                    <div
                                      class="table-wrap table anchored whole_rhythm"
                                      id="T3"
                                    >
                                      <h3>Table 3</h3>
                                      <!--caption a7-->
                                      <div class="caption">
                                        <p id="__p9">
                                          Thermodynamic parameters from
                                          van&#x02019;t Hoff analysis of the
                                          thermal denaturation of sequences
                                          forming unimolecular antiparallel
                                          quadruplexes in 25 mM KCl
                                        </p>
                                      </div>
                                      <div
                                        data-largeobj=""
                                        data-largeobj-link-rid="largeobj_idm139857529150640"
                                        class="xtable"
                                      >
                                        <table
                                          frame="above"
                                          rules="groups"
                                          class="rendered small default_table"
                                        >
                                          <thead>
                                            <tr>
                                              <th
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                Sequence
                                              </th>
                                              <th
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                T<sub>m</sub> (&#x000b0;C,
                                                &#x000b1; 0.5)
                                              </th>
                                              <th
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                &#x00394;H&#x000b0; (kcal/mol,
                                                &#x000b1;2)
                                              </th>
                                              <th
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                &#x00394;S&#x000b0;
                                                (cal/(mol-deg), &#x000b1;4)
                                              </th>
                                              <th
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                &#x00394;G&#x000b0;(37
                                                &#x000b0;C) (kcal/mol,
                                                &#x000b1;0.2)
                                              </th>
                                            </tr>
                                          </thead>
                                          <tbody>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBA</strong>
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                45.9
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                40.3
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                127
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                0.93
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>dTBAr2</strong>
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                51.8
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                45.3
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                139
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                2.21
                                              </td>
                                            </tr>
                                            <tr>
                                              <td
                                                align="left"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                <strong>rTBAd1</strong>
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                49.4
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                46.2
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                144
                                              </td>
                                              <td
                                                align="center"
                                                valign="middle"
                                                rowspan="1"
                                                colspan="1"
                                              >
                                                1.72
                                              </td>
                                            </tr>
                                          </tbody>
                                        </table>
                                      </div>
                                      <div
                                        id="largeobj_idm139857529150640"
                                        class="largeobj-link align_right"
                                        style="display: none"
                                      >
                                        <a target="object"
                                          >Open in a separate window</a
                                        >
                                      </div>
                                    </div>
                                  </div>
                                  <div id="S11" class="sec sec-last">
                                    <h3 id="S11title">
                                      Imino proton NMR spectra
                                    </h3>
                                    <p id="P25" class="p p-first">
                                      One of the signature properties of
                                      structures based on the guanine quartet
                                      involves imino proton resonances in the
                                      &#x0223c;10.5 - 12.5 ppm range
                                      <sup
                                        ><a rid="R9" class="bibr popnode"
                                          >9</a
                                        > </sup
                                      >. Thus we measured the imino proton
                                      spectrum for both
                                      <strong>dTBA</strong> and
                                      <strong>rTBA</strong> in order to confirm
                                      the presence of a quadruplex conformation
                                      in these sequences. The imino proton
                                      spectrum of <strong>dTBA</strong> has been
                                      well characterized
                                      <sup
                                        ><a rid="R8" class="bibr popnode">8</a>
                                      </sup>
                                      and we include it here simply for
                                      reference. Results for both
                                      <strong>dTBA</strong> and
                                      <strong>rTBA</strong> are presented in
                                      <a
                                        target="figure"
                                        class="fig-table-link figpopup"
                                        rid-figpopup="F5"
                                        rid-ob="ob-F5"
                                        co-legend-rid="lgnd_F5"
                                        ><span>Figure 5</span> </a
                                      >. The spectrum for
                                      <strong>dTBA</strong> resembles that
                                      already reported, again indicative of
                                      guanine imino protons engaged in quartet
                                      hydrogen bonding. Similarly, the spectrum
                                      for <strong>rTBA</strong> also contains
                                      resonances characteristic of guanine
                                      quartets.
                                    </p>
                                    <!--fig ft0--><!--fig mode=article f1-->
                                    <div
                                      class="fig iconblock whole_rhythm clearfix"
                                      id="F5"
                                      co-legend-rid="lgnd_F5"
                                    >
                                      <a
                                        target="figure"
                                        rid-figpopup="F5"
                                        rid-ob="ob-F5"
                                        ><!--fig/graphic|fig/alternatives/graphic mode="anchored" m1-->
                                        <div
                                          data-largeobj=""
                                          data-largeobj-link-rid="largeobj_idm139857517232288"
                                          class="figure"
                                        >
                                          <img
                                            class="fig-image"
                                            alt="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0005.jpg"
                                            title="An external file that holds a picture, illustration, etc.&#10;Object name is nihms-60994-f0005.jpg"
                                            src="http://img.staging.deepbiogroup.com/AptamerImageTotals/774568600004.jpg"
                                          />
                                        </div>
                                        <div
                                          id="largeobj_idm139857517232288"
                                          class="largeobj-link align_right"
                                          style="display: none"
                                        >
                                          <a target="object"
                                            >Open in a separate window</a
                                          >
                                        </div>
                                      </a>
                                      <div class="icnblk_cntnt" id="lgnd_F5">
                                        <div>
                                          <a
                                            class="figpopup"
                                            target="figure"
                                            rid-figpopup="F5"
                                            rid-ob="ob-F5"
                                            >Figure 5</a
                                          >
                                        </div>
                                        <!--caption a7-->
                                        <div class="caption">
                                          <p id="__p6">
                                            Quartet imino proton spectra for
                                            <strong>rTBA</strong> (top) and
                                            <strong>dTBA</strong> (bottom), 500
                                            &#x003bc;M strand, in 10 mM
                                            perdeuterated Tris-acetate buffer,
                                            pH 6.8, and 25 mM KCl, 5 &#x000b0;C,
                                            .
                                          </p>
                                        </div>
                                      </div>
                                    </div>
                                    <p id="P26" class="p p-last">
                                      The spectrum of each structure covers a
                                      similar range of frequencies, with that
                                      for
                                      <strong>dTBA</strong> slightly smaller
                                      than that for <strong>rTBA</strong>.
                                      Additionally, the resolution is
                                      substantially better in the spectrum for
                                      <strong>dTBA</strong>. The apparently
                                      broader lines in the
                                      <strong>rTBA</strong> spectrum may be due
                                      to the fact that this structure consists
                                      of more than one strand and its spectrum
                                      may possess more than eight resonances.
                                      For our purposes, however, the
                                      significance of these spectra is that they
                                      confirm the presence of a guanine quartet
                                      based structure for <strong>rTBA</strong>,
                                      the all-RNA version of this sequence.
                                    </p>
                                  </div>
                                </div>
                                <div id="S12" class="tsec sec">
                                  <h2
                                    class="head no_bottom_margin"
                                    id="S12title"
                                  >
                                    Discussion
                                  </h2>
                                  <p id="P27" class="p p-first">
                                    Guanine quadruplex stability is affected by
                                    multiple forces. Of primary significance is
                                    the ability to form complete guanine
                                    quartets. In general, the more quartets in a
                                    structure, the more stable it will be, all
                                    other things held constant. In the case of
                                    folded quadruplexes, we can anticipate a
                                    role for the loop sequences in modulating
                                    the stability of these structures. We have
                                    previously shown the importance of loop
                                    length and sequence in determining the
                                    thermal stability of <strong>dTBA</strong>
                                    <sup
                                      ><a
                                        rid="R29"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393645"
                                        >29</a
                                      > </sup
                                    >. More recently, the effect of loop length
                                    on quadruplex stability has been
                                    demonstrated in other sequence contexts
                                    <sup
                                      ><a
                                        rid="R26"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393615"
                                        >26</a
                                      > </sup
                                    >. Evidence suggesting the possibility of
                                    parallel, unimolecular quadruplexes appeared
                                    over a decade ago. For example, in an early
                                    study on the human telomere repeat sequence
                                    <sup
                                      ><a
                                        rid="R30"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393651"
                                        >30</a
                                      > </sup
                                    >, CD spectra, in the presence of K<sup
                                      >+</sup
                                    >
                                    ions, showed peaks at both 265 nm and 293
                                    nm, suggesting the presence of both parallel
                                    and antiparallel quadruplex structures.
                                    Several years later, a report appeared
                                    describing both DNA and RNA forms of the
                                    <em>Tetrahymena</em> repeat sequence,
                                    d(T<sub>2</sub>G<sub>4</sub>)<sub>4</sub>,
                                    including data suggesting that the RNA
                                    oligonucleotide was both unimolecular and
                                    parallel
                                    <sup
                                      ><a rid="R31" class="bibr popnode"
                                        >31</a
                                      > </sup
                                    >.
                                  </p>
                                  <p id="P28">
                                    More recently, several structural studies
                                    demonstrating a DNA parallel quadruplex
                                    conformation have appeared. Patel and
                                    co-workers described an unusual
                                    four-stranded DNA structure, in the presence
                                    of 150 mM Na<sup>+</sup>, in which two
                                    strands of d(GGAGGAG) formed a quartet and
                                    an AGGGA hexad, with all GG segments
                                    parallel to each other; two such structures
                                    complexed with each other via stacking of
                                    their respective hexads
                                    <sup
                                      ><a
                                        rid="R11"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393672"
                                        >11</a
                                      > </sup
                                    >. Thus within each two-stranded
                                    hexad-quartet structure, all GG segments are
                                    parallel to each other, but those of one
                                    such structure are antiparallel to those of
                                    the other.
                                  </p>
                                  <p id="P29">
                                    Katahira and co-workers have reported the
                                    NMR solution structure of the 12-mer
                                    d(GGA)<sub>4</sub>
                                    in the presence of 10 mM NaCl and 100 mM KCl
                                    <sup
                                      ><a
                                        rid="R10"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393676"
                                        >10</a
                                      > </sup
                                    >. This structure involves a single strand
                                    folding in a parallel fashion to form one
                                    guanine quartet stacked over a GAGAGAG
                                    septet. As in the AGGGGA hexad structure
                                    mentioned above, two such structures stack
                                    via their GAGAGAG heptads, giving rise to a
                                    two-stranded structure. Shortly following
                                    that report, an X-ray crystal structure for
                                    the human telomere sequence,
                                    d(AG<sub>3</sub>(T<sub>2</sub>AG<sub>3</sub>)<sub>3</sub>),
                                    appeared
                                    <sup
                                      ><a
                                        rid="R12"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393684"
                                        >12</a
                                      > </sup
                                    >. This structure, obtained in the presence
                                    of K<sup>+</sup> ions (and a
                                    quadruplex-binding ligand), exhibited a
                                    parallel folding topology, in striking
                                    contrast to the antiparallel, folded
                                    structure reported about a decade earlier
                                    for the same sequence by NMR in solution, in
                                    the presence of Na<sup>+</sup> ions
                                    <sup
                                      ><a
                                        rid="R13"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393654"
                                        >13</a
                                      > </sup
                                    >. More recently, evidence for a
                                    two-stranded, parallel quadruplex formed by
                                    a two-fold repeat of the human telomere as
                                    been described, in which the two strands
                                    each contribute half of the guanines in each
                                    quartet
                                    <sup
                                      ><a
                                        rid="R32"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_542189906"
                                        >32</a
                                      > </sup
                                    >. G-rich sequences from the control region
                                    of the <em>c-myc</em> promoter has also been
                                    shown to form a unimolecular parallel
                                    quadruplex
                                    <sup
                                      ><a
                                        rid="R16"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393680"
                                        >16</a
                                      >
                                    </sup>
                                    <sup>-</sup>
                                    <sup
                                      ><a
                                        rid="R18"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_542189904"
                                        >18</a
                                      > </sup
                                    >.
                                  </p>
                                  <p id="P30">
                                    RNA quadruplexes have been studied less
                                    extensively than DNA quadruplexes. One
                                    example is a study demonstrating different
                                    quadruplex structures formed by
                                    d(G<sub>2</sub>AG<sub>2</sub>T<sub>4</sub>G<sub>2</sub>AG<sub>2</sub>A)
                                    and its RNA analog,
                                    r(G<sub>2</sub>AG<sub>2</sub>U<sub>4</sub>G<sub>2</sub>AG<sub>2</sub>A);
                                    the DNA sequence forms a typical bimolecular
                                    antiparallel, diagonal loop type structure
                                    while the RNA sequence forms a dimer of two
                                    parallel unimolecular quadruplexes
                                    <sup
                                      ><a
                                        rid="R33"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393658"
                                        >33</a
                                      >
                                    </sup>
                                    <sup>, </sup>
                                    <sup
                                      ><a
                                        rid="R34"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393612"
                                        >34</a
                                      > </sup
                                    >. This result echoes that mentioned
                                    earlier, in which CD and gel electrophoresis
                                    data indicated, under certain conditions, an
                                    antiparallel, unimolecular structure for
                                    d(T<sub>2</sub>G<sub>4</sub>)<sub>4</sub> in
                                    contrast to a parallel, unimolecular
                                    structure for
                                    r(U<sub>2</sub>G<sub>4</sub>)<sub>4</sub>
                                    <sup
                                      ><a rid="R31" class="bibr popnode"
                                        >31</a
                                      > </sup
                                    >. Some physical studies have been carried
                                    out on an RNA quadruplex-containing aptamer
                                    targeted to the Fragile-X mental retardation
                                    protein, although its folding topology is
                                    not apparent
                                    <sup
                                      ><a rid="R35" class="bibr popnode"
                                        >35</a
                                      > </sup
                                    >.
                                  </p>
                                  <p id="P31">
                                    At this time, then, there is ample
                                    documentation of both parallel and
                                    antiparallel folded quadruplexes, yet
                                    relatively little is known regarding the
                                    forces which determine how a specific
                                    sequence folds. One study has shown that the
                                    normally antiparallel folded quadruplex
                                    formed by
                                    d(G<sub>4</sub>(T<sub>4</sub>G<sub>4</sub>)<sub>3</sub>)
                                    can be induced to fold to a parallel
                                    quadruplex in the presence of K<sup>+</sup>
                                    when certain single nucleosides are replaced
                                    with a locked nucleic acid (LNA) analog
                                    <sup
                                      ><a
                                        rid="R36"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393675"
                                        >36</a
                                      > </sup
                                    >. No clear change from antiparallel to
                                    parallel was reported, however, in the
                                    presence of Na<sup>+</sup>. This approach
                                    also sought to exploit the preference of the
                                    LNA analog for the
                                    <em>anti</em> conformation, yet in two of
                                    the three cases where conversion from
                                    antiparallel to parallel was essentially
                                    complete, the substitutions occurred at
                                    sites that normally possess the
                                    <em>anti</em> conformation. Thus the
                                    rationale for those results is not clear. In
                                    the results presented here, the role of the
                                    substituted nucleosides is unambiguously
                                    demonstrated via the control sequences and
                                    the results are seen for both K<sup>+</sup>
                                    and Na<sup>+</sup> .
                                  </p>
                                  <p id="P32">
                                    A more recent report has appeared describing
                                    the effect of replacing all quartet
                                    deoxyguanosines in
                                    <strong>dTBA</strong> with the LNA analog,
                                    which led to a structure with a
                                    parallel-like CD spectrum and substantially
                                    lower thermal stability than
                                    <strong>dTBA</strong>
                                    <sup
                                      ><a
                                        rid="R37"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393643"
                                        >37</a
                                      > </sup
                                    >. No information concerning the
                                    molecularity of this structure was provided,
                                    although the observed hysteresis in CD
                                    melting profiles for this modified sequence
                                    indicated very slow kinetics, consistent
                                    with the possibility of a multi-stranded
                                    species. In this regard, it is of interest
                                    to note that some two-stranded quadruplexes
                                    have been shown to exhibit very slow
                                    kinetics of formation/dissociation
                                    <sup
                                      ><a
                                        rid="R32"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_542189903"
                                        >32</a
                                      >
                                    </sup>
                                    and thus the observation of hysteresis in
                                    melting curves is consistent with either
                                    two- or four-stranded structures. The
                                    specific role of they <em>syn</em> -
                                    <em>anti</em> properties of the LNA analog
                                    was not considered.
                                  </p>
                                  <p id="P33">
                                    The potential role of loops in directing a
                                    parallel or antiparallel fold has been
                                    investigated by Neidle and co-workers
                                    <sup
                                      ><a
                                        rid="R26"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393642"
                                        >26</a
                                      > </sup
                                    >. In that study, it was concluded that loop
                                    length may play a major role in determining
                                    the overall fold. Specifically, the study
                                    finds that the parallel structure is the
                                    only stable form when all loops consist of a
                                    single base; in most other cases, both
                                    parallel and antiparallel folds are
                                    possible. This conclusion is supported by
                                    previously published structures of parallel
                                    quadruplexes, both DNA and RNA, which
                                    possess two or three single-base loops
                                    <sup
                                      ><a
                                        rid="R6"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393641"
                                        >6</a
                                      >
                                    </sup>
                                    <sup>, </sup>
                                    <sup
                                      ><a
                                        rid="R10"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393653"
                                        >10</a
                                      >
                                    </sup>
                                    <sup>, </sup>
                                    <sup
                                      ><a
                                        rid="R17"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393619"
                                        >17</a
                                      >
                                    </sup>
                                    <sup>, </sup>
                                    <sup
                                      ><a
                                        rid="R34"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393634"
                                        >34</a
                                      > </sup
                                    >.
                                  </p>
                                  <p id="P34">
                                    The influence of loops on the CD spectrum of
                                    quadruplexes has also been considered. For
                                    example, in a study on the CD spectra of a
                                    series of telomere sequences from
                                    vertebrates, Bolton and co-workers have
                                    suggested that in spectra possessing
                                    positive peaks near 260 and 290 nm, that the
                                    longer wavelength peak may arise from the
                                    three-base (TTA) loops while the other peak
                                    arises from the quartet core
                                    <sup
                                      ><a
                                        rid="R38"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393670"
                                        >38</a
                                      > </sup
                                    >. Similarly, others have shown that the CD
                                    spectrum of the four-fold repeat of
                                    <em>Tetrahymena</em>,
                                    d(T<sub>2</sub>G<sub>4</sub>)<sub>4</sub>,
                                    in the presence of NaCl possesses positive
                                    peaks at both 260 and 290 nm
                                    <sup
                                      ><a rid="R31" class="bibr popnode">31</a>
                                    </sup>
                                    <sup>, </sup>
                                    <sup
                                      ><a
                                        rid="R39"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393626"
                                        >39</a
                                      >
                                    </sup>
                                    and one explanation is that the unusual fold
                                    of this sequence, involving two lateral
                                    loops and one double-reversal, or propeller,
                                    loop
                                    <sup
                                      ><a
                                        rid="R40"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393673"
                                        >40</a
                                      >
                                    </sup>
                                    is both part parallel and part antiparallel,
                                    and thus may have a CD spectrum with both
                                    peaks. However, the alternative explanation
                                    attributing the two positive peaks to two
                                    different species cannot be ruled out,
                                    especially in light of gel results
                                    suggesting the presence of two different
                                    species under these conditions
                                    <sup
                                      ><a rid="R31" class="bibr popnode"
                                        >31</a
                                      > </sup
                                    >.
                                  </p>
                                  <p id="P35">
                                    Our CD results provide some additional
                                    insight into this question, as parallel and
                                    antiparallel species display CD spectra
                                    possessing either the positive peak at 265
                                    nm or at 293 nm, but not both. The loops,
                                    likely composed of two or three bases, must
                                    have different folds yet do not appear to
                                    make a separate contribution to the CD
                                    signal. Of course, it is difficult to
                                    generalize from a single example, and thus
                                    the general CD properties of parallel and
                                    antiparallel quadruplexes remain to be
                                    elaborated.
                                  </p>
                                  <p id="P36">
                                    The main focus, however, of this work is to
                                    investigate the effect of the guanine
                                    nucleoside on the nature of the quadruplex
                                    fold. Specifically, we have demonstrated
                                    that dG residues at certain positions can be
                                    replaced with rG residues (a difference of a
                                    single oxygen atom on the sugar ring)
                                    resulting in a major change in the overall
                                    folding topology. Starting with all-DNA
                                    (antiparallel conformation), substitution of
                                    specific dG residues can reverse the sense
                                    of the fold. Similarly, the parallel fold of
                                    the all-RNA sequence can be reversed by
                                    specific substitution of rG with dG. We
                                    rationalize these changes by noting that RNA
                                    nucleosides exhibit a strong preference for
                                    the
                                    <em>anti</em> conformation about the
                                    glycosidic bond, related to the fact that
                                    ribonucleosides exhibit the C3&#x02032;-endo
                                    (N) type of sugar pucker. This preference
                                    for the <em>anti</em> conformation in RNA is
                                    not absolute, as there are examples of RNA
                                    structures containing
                                    <em>syn</em> ribonucleosides, such as Z RNA
                                    <sup
                                      ><a
                                        rid="R20"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393663"
                                        >20</a
                                      > </sup
                                    >, hairpins
                                    <sup
                                      ><a
                                        rid="R41"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393677"
                                        >41</a
                                      > </sup
                                    >, G-A mismatches in duplexes
                                    <sup
                                      ><a
                                        rid="R42"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393628"
                                        >42</a
                                      >
                                    </sup>
                                    and ribozymes
                                    <sup
                                      ><a
                                        rid="R43"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393665"
                                        >43</a
                                      > </sup
                                    >. Nonetheless, within the context of the
                                    sequences studied here, the inherent
                                    preference of ribonucleosides for the
                                    <em>anti</em> conformation appears to be
                                    sufficiently strong to force quadruplex
                                    refolding.
                                  </p>
                                  <p id="P37" class="p">
                                    In addition to reversing the quadruplex fold
                                    from antiparallel to parallel, specific
                                    replacement of dG with rG also changes the
                                    molecularity of the structure from one to
                                    two strands. At this time, we can only
                                    speculate in a limited manner on the
                                    arrangement of the two strands in the
                                    parallel quadruplex formed by
                                    <strong>dTBAr1</strong> (and by
                                    <strong>rTBA</strong> and
                                    <strong>rTBAd2</strong> as well). As
                                    illustrated in
                                    <a
                                      target="figure"
                                      class="fig-table-link figpopup"
                                      rid-figpopup="F1"
                                      rid-ob="ob-F1"
                                      co-legend-rid="lgnd_F1"
                                      ><span>Figure 1</span> </a
                                    >, several different arrangements are
                                    possible for parallel quadruplexes: (i) a
                                    single unimolecular species -
                                    <a
                                      target="figure"
                                      class="fig-table-link figpopup"
                                      rid-figpopup="F1"
                                      rid-ob="ob-F1"
                                      co-legend-rid="lgnd_F1"
                                      ><span>Figure 1D</span> </a
                                    >, (ii) a dimer of unimolecular quadruplexes
                                    and (iii) a single quadruplex composed of
                                    two strands -
                                    <a
                                      target="figure"
                                      class="fig-table-link figpopup"
                                      rid-figpopup="F1"
                                      rid-ob="ob-F1"
                                      co-legend-rid="lgnd_F1"
                                      ><span>Figure 1E</span> </a
                                    >. Our results indicate that the latter two
                                    forms are possible arrangements for the
                                    parallel structures investigated here;
                                    additional studies will be necessary to
                                    distinguish (ii) from (iii). Examples of
                                    type (ii) structures in the literature
                                    involve a single quartet stacked on a larger
                                    guanine quartet-containing platform composed
                                    of purines, such as an AGGGGA hexad
                                    <sup
                                      ><a
                                        rid="R11"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393669"
                                        >11</a
                                      >
                                    </sup>
                                    <sup>, </sup>
                                    <sup
                                      ><a
                                        rid="R34"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393657"
                                        >34</a
                                      >
                                    </sup>
                                    or an GAGAGAG heptad
                                    <sup
                                      ><a
                                        rid="R10"
                                        class="bibr popnode tag_hotlink tag_tooltip"
                                        id="__tag_160393674"
                                        >10</a
                                      > </sup
                                    >. Given the sequence of
                                    <strong>TBA</strong>, this may be unlikely
                                    to form in the parallel quadruplexes studied
                                    here, leaving type (iii) as the more likely
                                    strand configuration.
                                  </p>
                                  <div id="S13" class="sec sec-last">
                                    <h3 id="S13title">
                                      Energetics of the parallel fold
                                    </h3>
                                    <p id="P38" class="p p-first">
                                      It is well appreciated experimentally that
                                      in most DNA and RNA structures, the
                                      <em>anti</em> conformation about the
                                      glycoside bond is more frequently observed
                                      than the <em>syn</em> conformation,
                                      implying that the former is more stable
                                      than the latter. Relating these
                                      observations to the conformation
                                      properties of the nucleic acid building
                                      blocks is considerably more complicated,
                                      as the glycosidic torsion angle is coupled
                                      to other degrees of freedom, such as sugar
                                      pucker. For example, solution studies on
                                      purine nucleosides indicate only
                                      relatively small differences between
                                      <em>syn</em> and
                                      <em>anti</em> conformations
                                      <sup
                                        ><a rid="R19" class="bibr popnode"
                                          >19</a
                                        > </sup
                                      >, yet this similarity in energy is not
                                      observed at the oligo- or polynucleotide
                                      level. A clearer correlation is seen,
                                      however, regarding sugar pucker, with
                                      ribonucleosides preferring the C3&#x02032;
                                      pucker and deoxyribonucleosides preferring
                                      the C2&#x02032; pucker. Furthermore,
                                      computations have led to quite different
                                      energetics between the various
                                      conformational states of nucleosides and
                                      nucleotides
                                      <sup
                                        ><a rid="R44" class="bibr popnode"
                                          >44</a
                                        > </sup
                                      >.
                                    </p>
                                    <p id="P39">
                                      The results described herein demonstrate
                                      that the observed preference of
                                      ribonucleosides for the
                                      <em>anti</em> conformation about the
                                      glycosidic bond in a large number of
                                      structures also holds for the guanine
                                      quadruplex. The energetic difference
                                      between the <em>syn</em> and
                                      <em>anti</em> conformations of rG,
                                      incorporated into oligomeric structures,
                                      is sufficiently large to destabilize the
                                      antiparallel fold relative to the parallel
                                      fold. Similarly, the relative ease with
                                      which dG can exhibit the
                                      <em>syn</em> conformation reverses the
                                      situation, resulting in an antiparallel
                                      fold for a mainly RNA chimeric sequence.
                                      Thus there does not appear to be anything
                                      inherent to RNA chemistry or structure
                                      preventing antiparallel folding, other
                                      than the glycosidic bond conformational
                                      properties. The switch in folding is not
                                      the only change that occurs, however, as
                                      the parallel species examined here consist
                                      of more than one strand, while the
                                      antiparallel species are unimolecular.
                                      This observation raises the question of
                                      the relationship between folding topology
                                      and molecularity. The
                                      <strong>TBA</strong> sequence presents no
                                      obvious obstacle to simply forming a
                                      unimolecular, parallel quadruplex.
                                      Unimolecular parallel structures have been
                                      reported containing one-base, two-base and
                                      three-base loops
                                      <sup
                                        ><a
                                          rid="R17"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393678"
                                          >17</a
                                        >
                                      </sup>
                                      <sup>, </sup>
                                      <sup
                                        ><a
                                          rid="R26"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393661"
                                          >26</a
                                        > </sup
                                      >. Apparently there is some driving force
                                      for a two-stranded, parallel structure in
                                      this case such that the unimolecular
                                      species has a higher free energy than the
                                      corresponding two-stranded structure,
                                      suggesting that the entropic cost of
                                      associating two strands is less than the
                                      enthalpic cost of forming the unimolecular
                                      parallel conformation.
                                    </p>
                                    <p id="P40">
                                      One possible factor influencing the
                                      molecularity of parallel quadruplexes is
                                      the sequence in the loops. All of the
                                      known structures of unimolecular parallel
                                      DNA quadruplexes, i.e. those in which a
                                      single strand folds into a complete
                                      parallel quadruplex, contain adenine in
                                      one or more loops and also contain at
                                      least one single-base loop
                                      <sup
                                        ><a
                                          rid="R10"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393649"
                                          >10</a
                                        >
                                      </sup>
                                      <sup>, </sup>
                                      <sup
                                        ><a
                                          rid="R12"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393638"
                                          >12</a
                                        >
                                      </sup>
                                      <sup>, </sup>
                                      <sup
                                        ><a
                                          rid="R17"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393632"
                                          >17</a
                                        >
                                      </sup>
                                      <sup>, </sup>
                                      <sup
                                        ><a
                                          rid="R18"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_542189907"
                                          >18</a
                                        > </sup
                                      >. In contrast, the TBA sequence studied
                                      here contains no adenine at all and no
                                      single-base loop sequence. This suggests a
                                      possible role for loop sequence in
                                      determining the folding pattern for
                                      quadruplexes and also is consistent with
                                      earlier studies indicating that
                                      single-base loops are most readily
                                      accommodated in unimolecular parallel
                                      quadruplexes
                                      <sup
                                        ><a
                                          rid="R26"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393627"
                                          >26</a
                                        > </sup
                                      >.
                                    </p>
                                    <p id="P41">
                                      While it is somewhat premature to
                                      generalize, all RNA quadruplexes
                                      investigated to date appear to exhibit a
                                      parallel folding topology, while only DNA
                                      quadruplexes have been found in both
                                      parallel and antiparallel folds. Such
                                      differences could have important
                                      biological implications. For example, the
                                      intramolecular guanine quadruplex in mRNA
                                      that binds the fragile-X mental
                                      retardation protein
                                      <sup
                                        ><a
                                          rid="R7"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393662"
                                          >7</a
                                        >
                                      </sup>
                                      is likely a parallel, rather than an
                                      antiparallel, structure. Formation of
                                      8-methylguanine from exposure to certain
                                      carcinogens has been reported
                                      <sup
                                        ><a rid="R45" class="bibr popnode"
                                          >45</a
                                        > </sup
                                      >; this could potentially occur in both
                                      DNA and RNA <em>in vivo</em>, and impact
                                      the nature of quadruplexes formed in
                                      G-rich regions of the genome or of RNA,
                                      due to the influence of methylation at the
                                      8 position on the syn-anti conformational
                                      preferences of the modified nucleoside.
                                      The inactivity of the RNA version of a DNA
                                      quadruplex aptamer that binds ATP could be
                                      due to a change from antiparallel to
                                      parallel folding
                                      <sup
                                        ><a
                                          rid="R46"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393666"
                                          >46</a
                                        > </sup
                                      >. Finally, it is likely that antiparallel
                                      quadruplex structures proposed for G-rich
                                      RNA sequences, such as that identified by
                                      <em>in vitro</em> selection to bind
                                      tightly to prions
                                      <sup
                                        ><a
                                          rid="R47"
                                          class="bibr popnode tag_hotlink tag_tooltip"
                                          id="__tag_160393648"
                                          >47</a
                                        > </sup
                                      >, will need revision.
                                    </p>
                                    <p id="P42" class="p p-last">
                                      In summary, we have demonstrated how to
                                      engineer the overall folding pattern of
                                      guanine quadruplexes by making specific
                                      substitutions of ribo- for
                                      deoxyriboguanosines, or vice versa. These
                                      results clearly establish the role of
                                      individual nucleoside conformational
                                      preferences on the overall quadruplex
                                      fold, and illustrate how a minor
                                      modification, addition or deletion of a
                                      single oxygen atom on several nucleosides,
                                      can have a profound impact on nucleic acid
                                      secondary, tertiary, and quaternary
                                      structure.
                                    </p>
                                  </div>
                                </div>
                                <div id="S14" class="tsec sec">
                                  <h2
                                    class="head no_bottom_margin"
                                    id="S14title"
                                  >
                                    Acknowledgment
                                  </h2>
                                  <div class="sec">
                                    <p id="__p1">
                                      We are grateful to Dr. Dan Minor for
                                      access to his CD spectrophotometer. This
                                      work was supported by NIH grant GM067607.
                                    </p>
                                  </div>
                                </div>
                                <div id="idm139857522601744" class="tsec sec">
                                  <h2
                                    class="head no_bottom_margin"
                                    id="idm139857522601744title"
                                  >
                                    References
                                  </h2>
                                  <div
                                    class="ref-list-sec sec"
                                    id="reference-list"
                                  >
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R1"
                                    >
                                      (1)
                                      <span class="citation"
                                        >Shafer RH, Smirnov I.
                                        <span
                                          ><span class="ref-journal"
                                            >Biopolymers. </span
                                          >2001;<span class="ref-vol">56</span
                                          >:209\xe2\x80\x93227.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R2"
                                    >
                                      (2)
                                      <span class="citation"
                                        >Zahler AM, Williamson JR, Cech TR,
                                        Prescott DM.
                                        <span
                                          ><span class="ref-journal"
                                            >Nature. </span
                                          >1991;<span class="ref-vol">350</span
                                          >:718\xe2\x80\x9320.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R3"
                                    >
                                      (3)(a)
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2b2d160"
                                        >Simonsson T, Pecinka P, Kubista M.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleic Acids Res. </span
                                          >1998;<span class="ref-vol">26</span
                                          >:1167\xe2\x80\x9372.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2b2d340"
                                        ><strong> (b) </strong>Siddiqui-Jain A,
                                        Grand CL, Bearss DJ, Hurley LH.
                                        <span
                                          ><span class="ref-journal"
                                            >Proc Natl Acad Sci U S A. </span
                                          >2002;<span class="ref-vol">99</span
                                          >:11593\xe2\x80\x938.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R4"
                                    >
                                      (4)
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2b2d5e0"
                                        >Neidle S, Read MA.
                                        <span
                                          ><span class="ref-journal"
                                            >Biopolymers. </span
                                          >2000;<span class="ref-vol">56</span
                                          >:195\xe2\x80\x93208.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2c3b990"
                                        ><strong> (b) </strong>Hurley LH,
                                        Wheelhouse RT, Sun D, Kerwin SM, Salazar
                                        M, Fedoroff OY, Han FX, Han H, Izbicka
                                        E, Von Hoff DD.
                                        <span
                                          ><span class="ref-journal"
                                            >Pharmacol Ther. </span
                                          >2000;<span class="ref-vol">85</span
                                          >:141\xe2\x80\x9358.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R5"
                                    >
                                      (5)
                                      <span class="citation"
                                        >Jing N, Hogan ME.
                                        <span
                                          ><span class="ref-journal"
                                            >Journal of Biological Chemistry. </span
                                          >1998;<span class="ref-vol">273</span
                                          >:34992\xe2\x80\x939.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R6"
                                    >
                                      (6)
                                      <span class="citation"
                                        >Phan AT, Kuryavyi V, Ma JB, Faure A,
                                        Andreola ML, Patel DJ.
                                        <span
                                          ><span class="ref-journal"
                                            >Proc Natl Acad Sci U S A. </span
                                          >2005;<span class="ref-vol">102</span
                                          >:634\xe2\x80\x939.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R7"
                                    >
                                      (7)
                                      <span class="citation"
                                        >Darnell JC, Jensen KB, Jin P, Brown V,
                                        Warren ST, Darnell RB.
                                        <span
                                          ><span class="ref-journal"
                                            >Cell. </span
                                          >2001;<span class="ref-vol">107</span
                                          >:489\xe2\x80\x9399.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R8"
                                    >
                                      (8)(a)
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2c3c710"
                                        >Macaya RF, Schultze P, Smith FW, Roe
                                        JA, Feigon J.
                                        <span
                                          ><span class="ref-journal"
                                            >Proc Natl Acad Sci U S A. </span
                                          >1993;<span class="ref-vol">90</span
                                          >:3745\xe2\x80\x939.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2c3c9b0"
                                        ><strong> (b) </strong>Wang KY, McCurdy
                                        S, Shea RG, Swaminathan S, Bolton PH.
                                        <span
                                          ><span class="ref-journal"
                                            >Biochemistry. </span
                                          >1993;<span class="ref-vol">32</span
                                          >:1899\xe2\x80\x93904.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R9"
                                    >
                                      (9)(a)
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2c3ccb0"
                                        >Keniry MA.
                                        <span
                                          ><span class="ref-journal"
                                            >Biopolymers. </span
                                          >2001;<span class="ref-vol">56</span
                                          >:123\xe2\x80\x9346.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2c3cdd0"
                                        ><strong> (b) </strong>Patel DJ, Bouaziz
                                        S, Kettani A, Wang Y. Structures of
                                        guanine-rich and cytosine-rich
                                        quadruplexes formed in vitro by
                                        telomeric, centromeric and triplet
                                        repeat disease sequences. In: Neidle S,
                                        editor.
                                        <span class="ref-journal"
                                          >Oxford Handbook of Nucleic Acid
                                          Structures.</span
                                        >
                                        Oxford University Press; Oxford: 1999.
                                        pp. 349\xe2\x80\x93453.
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R10"
                                    >
                                      (10)
                                      <span class="citation"
                                        >Matsugami A, Ouhashi K, Kanagawa M, Liu
                                        H, Kanagawa S, Uesugi S, Katahira M.
                                        <span
                                          ><span class="ref-journal"
                                            >J Mol Biol. </span
                                          >2001;<span class="ref-vol">313</span
                                          >:255\xe2\x80\x9369.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R11"
                                    >
                                      (11)
                                      <span class="citation"
                                        >Kettani A, Gorin A, Majumdar A, Hermann
                                        T, Skripkin E, Zhao H, Jones R, Patel
                                        DJ.
                                        <span
                                          ><span class="ref-journal"
                                            >J Mol Biol. </span
                                          >2000;<span class="ref-vol">297</span
                                          >:627\xe2\x80\x9344.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R12"
                                    >
                                      (12)
                                      <span class="citation"
                                        >Parkinson GN, Lee MP, Neidle S.
                                        <span
                                          ><span class="ref-journal"
                                            >Nature. </span
                                          >2002;<span class="ref-vol">417</span
                                          >:876\xe2\x80\x9380.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R13"
                                    >
                                      (13)
                                      <span class="citation"
                                        >Wang Y, Patel DJ.
                                        <span
                                          ><span class="ref-journal"
                                            >Structure. </span
                                          >1993;<span class="ref-vol">1</span
                                          >:263\xe2\x80\x9382.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R14"
                                    >
                                      (14)
                                      <span class="citation"
                                        >Ourliac-Garnier I, Elizondo-Riojas MA,
                                        Redon S, Farrell NP, Bombard S.
                                        <span
                                          ><span class="ref-journal"
                                            >Biochemistry. </span
                                          >2005;<span class="ref-vol">44</span
                                          >:10620\xe2\x80\x9334.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R15"
                                    >
                                      (15)(a)
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2ef2bd0"
                                        >Qi J, Shafer RH.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleic Acids Res. </span
                                          >2005;<span class="ref-vol">33</span
                                          >:3185\xe2\x80\x9392.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2ef2d50"
                                        ><strong> (b) </strong>Li J, Correia JJ,
                                        Wang L, Trent JO, Chaires JB.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleic Acids Res. </span
                                          >2005;<span class="ref-vol">33</span
                                          >:4649\xe2\x80\x9359.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R16"
                                    >
                                      (16)
                                      <span class="citation"
                                        >Seenisamy J, Rezler EM, Powell TJ, Tye
                                        D, Gokhale V, Joshi CS, Siddiqui-Jain A,
                                        Hurley LH.
                                        <span
                                          ><span class="ref-journal"
                                            >J Am Chem Soc. </span
                                          >2004;<span class="ref-vol">126</span
                                          >:8702\xe2\x80\x939.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R17"
                                    >
                                      (17)
                                      <span class="citation"
                                        >Ambrus A, Chen D, Dai J, Jones RA, Yang
                                        D.
                                        <span
                                          ><span class="ref-journal"
                                            >Biochemistry. </span
                                          >2005;<span class="ref-vol">44</span
                                          >:2048\xe2\x80\x9358.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R18"
                                    >
                                      (18)
                                      <span class="citation"
                                        >Phan AT, Modi YS, Patel DJ.
                                        <span
                                          ><span class="ref-journal"
                                            >J Am Chem Soc. </span
                                          >2004;<span class="ref-vol">126</span
                                          >:8710\xe2\x80\x936.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R19"
                                    >
                                      (19)
                                      <span class="citation"
                                        >Saenger W.
                                        <span class="ref-journal"
                                          >Principles of Nucleic Acid
                                          Structure.</span
                                        >
                                        Springer-Verlag; Berlin: 1984. p. 556.
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R20"
                                    >
                                      (20)
                                      <span class="citation"
                                        >Hall K, Cruz P, Tinoco I, Jr., Jovin
                                        TM, van de Sande JH.
                                        <span
                                          ><span class="ref-journal"
                                            >Nature. </span
                                          >1984;<span class="ref-vol">311</span
                                          >:584\xe2\x80\x936.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R21"
                                    >
                                      (21)
                                      <span class="citation"
                                        >Gray DM, Hung SH, Johnson KH.
                                        <span
                                          ><span class="ref-journal"
                                            >Methods Enzymol. </span
                                          >1995;<span class="ref-vol">246</span
                                          >:19\xe2\x80\x9334.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R22"
                                    >
                                      (22)
                                      <span class="citation"
                                        >Piotto M, Saudek V, Sklenar V.
                                        <span
                                          ><span class="ref-journal"
                                            >J Biomol NMR. </span
                                          >1992;<span class="ref-vol">2</span
                                          >:661\xe2\x80\x935.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R23"
                                    >
                                      (23)
                                      <span class="citation"
                                        >Hardin CC, Perry AG, White K.
                                        <span
                                          ><span class="ref-journal"
                                            >Biopolymers. </span
                                          >2001;<span class="ref-vol">56</span
                                          >:147\xe2\x80\x9394.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R24"
                                    >
                                      (24)
                                      <span class="citation"
                                        >Lu M, Guo Q, Kallenbach NR.
                                        <span
                                          ><span class="ref-journal"
                                            >Biochemistry. </span
                                          >1993;<span class="ref-vol">32</span
                                          >:598\xe2\x80\x93601.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R25"
                                    >
                                      (25)
                                      <span class="citation"
                                        >Dapic V, Abdomerovic V, Marrington R,
                                        Peberdy J, Rodger A, Trent JO, Bates PJ.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleic Acids Res. </span
                                          >2003;<span class="ref-vol">31</span
                                          >:2097\xe2\x80\x93107.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R26"
                                    >
                                      (26)
                                      <span class="citation"
                                        >Hazel P, Huppert J, Balasubramanian S,
                                        Neidle S.
                                        <span
                                          ><span class="ref-journal"
                                            >J Am Chem Soc. </span
                                          >2004;<span class="ref-vol">126</span
                                          >:16405\xe2\x80\x9315.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R27"
                                    >
                                      (27)
                                      <span class="citation"
                                        >Smirnov I, Shafer RH.
                                        <span
                                          ><span class="ref-journal"
                                            >Journal of Molecular Biology. </span
                                          >2000;<span class="ref-vol">296</span
                                          >:1\xe2\x80\x935.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R28"
                                    >
                                      (28)
                                      <span class="citation"
                                        >Sacca B, Lacroix L, Mergny JL.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleic Acids Res. </span
                                          >2005;<span class="ref-vol">33</span
                                          >:1182\xe2\x80\x9392.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R29"
                                    >
                                      (29)
                                      <span class="citation"
                                        >Smirnov I, Shafer RH.
                                        <span
                                          ><span class="ref-journal"
                                            >Biochemistry. </span
                                          >2000;<span class="ref-vol">39</span
                                          >:1462\xe2\x80\x931468.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R30"
                                    >
                                      (30)
                                      <span class="citation"
                                        >Balagurumoorthy P, Brahmachari SK.
                                        <span
                                          ><span class="ref-journal"
                                            >J Biol Chem. </span
                                          >1994;<span class="ref-vol">269</span
                                          >:21858\xe2\x80\x9369.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R31"
                                    >
                                      (31)
                                      <span class="citation"
                                        >Sugimoto N, Ohmichi T, Saskai M.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleosides Nucleotides Nucl Acids. </span
                                          >1996;<span class="ref-vol">15</span
                                          >:559\xe2\x80\x93567.</span
                                        >
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R32"
                                    >
                                      (32)
                                      <span class="citation"
                                        >Phan AT, Patel DJ.
                                        <span
                                          ><span class="ref-journal"
                                            >J Am Chem Soc. </span
                                          >2003;<span class="ref-vol">125</span
                                          >:15021\xe2\x80\x937.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R33"
                                    >
                                      (33)
                                      <span class="citation"
                                        >Liu H, Kugimiya A, Sakurai T, Katahira
                                        M, Uesugi S.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleosides, Nucleotides, Nucleic
                                            Acids. </span
                                          >2002;<span class="ref-vol">21</span
                                          >:785\xe2\x80\x93801.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R34"
                                    >
                                      (34)
                                      <span class="citation"
                                        >Liu H, Matsugami A, Katahira M, Uesugi
                                        S.
                                        <span
                                          ><span class="ref-journal"
                                            >J Mol Biol. </span
                                          >2002;<span class="ref-vol">322</span
                                          >:955\xe2\x80\x9370.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R35"
                                    >
                                      (35)
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2f02e00"
                                        >Darnell JC, Jensen KB, Jin P, Brown V,
                                        Warren ST, Darnell RB.
                                        <span
                                          ><span class="ref-journal"
                                            >Cell. </span
                                          >2001;<span class="ref-vol">107</span
                                          >:489\xe2\x80\x9399.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2f03100"
                                        >Ramos A, Hollingworth D, Pastore A.
                                        <span
                                          ><span class="ref-journal">Rna. </span
                                          >2003;<span class="ref-vol">9</span
                                          >:1198\xe2\x80\x93207.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R36"
                                    >
                                      (36)
                                      <span class="citation"
                                        >Dominick PK, Jarstfer MB.
                                        <span
                                          ><span class="ref-journal"
                                            >J Am Chem Soc. </span
                                          >2004;<span class="ref-vol">126</span
                                          >:5050\xe2\x80\x931.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R37"
                                    >
                                      (37)
                                      <span class="citation"
                                        >Randazzo A, Esposito V, Ohlenschlager
                                        O, Ramachandran R, Virgilio A, Mayol L.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleosides Nucleotides Nucleic
                                            Acids. </span
                                          >2005;<span class="ref-vol">24</span
                                          >:795\xe2\x80\x93800.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R38"
                                    >
                                      (38)
                                      <span class="citation"
                                        >Rujan IN, Meleney JC, Bolton PH.
                                        <span
                                          ><span class="ref-journal"
                                            >Nucleic Acids Res. </span
                                          >2005;<span class="ref-vol">33</span
                                          >:2022\xe2\x80\x9331.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R39"
                                    >
                                      (39)
                                      <span class="citation"
                                        >Rezler EM, Seenisamy J, Bashyam S, Kim
                                        MY, White E, Wilson WD, Hurley LH.
                                        <span
                                          ><span class="ref-journal"
                                            >J Am Chem Soc. </span
                                          >2005;<span class="ref-vol">127</span
                                          >:9439\xe2\x80\x9347.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R40"
                                    >
                                      (40)
                                      <span class="citation"
                                        >Wang Y, Patel DJ.
                                        <span
                                          ><span class="ref-journal"
                                            >Structure. </span
                                          >1994;<span class="ref-vol">2</span
                                          >:1141\xe2\x80\x9356.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R41"
                                    >
                                      (41)
                                      <span class="citation"
                                        >Proctor DJ, Kierzek E, Kierzek R,
                                        Bevilacqua PC.
                                        <span
                                          ><span class="ref-journal"
                                            >J Am Chem Soc. </span
                                          >2003;<span class="ref-vol">125</span
                                          >:2390\xe2\x80\x931.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R42"
                                    >
                                      (42)
                                      <span class="citation"
                                        >Pan B, Mitra SN, Sundaralingam M.
                                        <span
                                          ><span class="ref-journal"
                                            >Biochemistry. </span
                                          >1999;<span class="ref-vol">38</span
                                          >:2826\xe2\x80\x9331.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R43"
                                    >
                                      (43)
                                      <span class="citation"
                                        >Sigel RK, Sashital DG, Abramovitz DL,
                                        Palmer AG, Butcher SE, Pyle AM.
                                        <span
                                          ><span class="ref-journal"
                                            >Nat Struct Mol Biol. </span
                                          >2004;<span class="ref-vol">11</span
                                          >:187\xe2\x80\x9392.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R44"
                                    >
                                      (44)(a)
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2f11000"
                                        >Gorb L, Shishkin O, Leszczynski J.
                                        <span
                                          ><span class="ref-journal"
                                            >J Biomol Struct Dyn. </span
                                          >2005;<span class="ref-vol">22</span
                                          >:441\xe2\x80\x9354.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2f111e0"
                                        ><strong> (b) </strong>Shishkin OV, Gorb
                                        L, Zhikol OA, Leszczynski J.
                                        <span
                                          ><span class="ref-journal"
                                            >J Biomol Struct Dyn. </span
                                          >2004;<span class="ref-vol">22</span
                                          >:227\xe2\x80\x9344.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2f11420"
                                        ><strong> (c) </strong>Foloppe N,
                                        Nilsson L, MacKerell AD., Jr.
                                        <span
                                          ><span class="ref-journal"
                                            >Biopolymers. </span
                                          >2001;<span class="ref-vol">61</span
                                          >:61\xe2\x80\x9376.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2f11600"
                                        ><strong> (d) </strong>Foloppe N,
                                        Hartmann B, Nilsson L, MacKerell AD.,
                                        Jr.
                                        <span
                                          ><span class="ref-journal"
                                            >Biophys J. </span
                                          >2002;<span class="ref-vol">82</span
                                          >:1554\xe2\x80\x9369.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R45"
                                    >
                                      (45)(a)
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2f118a0"
                                        >Netto LE, RamaKrishna NV, Kolar C,
                                        Cavalieri EL, Rogan EG, Lawson TA,
                                        Augusto O.
                                        <span
                                          ><span class="ref-journal"
                                            >J Biol Chem. </span
                                          >1992;<span class="ref-vol">267</span
                                          >:21524\xe2\x80\x937.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                      <span
                                        class="citation"
                                        id="N0x1d44980N0x2f11c00"
                                        ><strong> (b) </strong>Gasparutto D,
                                        Dherin C, Boiteux S, Cadet J.
                                        <span
                                          ><span class="ref-journal"
                                            >DNA Repair (Amst) </span
                                          >2002;<span class="ref-vol">1</span
                                          >:437\xe2\x80\x9347.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R46"
                                    >
                                      (46)
                                      <span class="citation"
                                        >Huizenga DE, Szostak JW.
                                        <span
                                          ><span class="ref-journal"
                                            >Biochemistry. </span
                                          >1995;<span class="ref-vol">34</span
                                          >:656\xe2\x80\x9365.</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                    <div
                                      class="ref-cit-blk half_rhythm"
                                      id="R47"
                                    >
                                      (47)
                                      <span class="citation"
                                        >Weiss S, Proske D, Neumann M, Groschup
                                        MH, Kretzschmar HA, Famulok M, Winnacker
                                        EL.
                                        <span
                                          ><span class="ref-journal"
                                            >J Virol. </span
                                          >1997;<span class="ref-vol">71</span
                                          >:8790\xe2\x80\x937.</span
                                        >
                                        <span class="nowrap"
                                          >[<a class="int-reflink"
                                            >PMC free article</a
                                          >]</span
                                        >
                                        [<a
                                          target="pmc_ext"
                                          ref="reftype=pubmed&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Entrez%7CPubMed%7CRecord"
                                          >PubMed</a
                                        >]
                                        <span class="nowrap"
                                          >[<a
                                            target="pmc_ext"
                                            ref="reftype=other&amp;article-id=2597528&amp;issue-id=174319&amp;journal-id=319&amp;FROM=Article%7CCitationRef&amp;TO=Content%20Provider%7CLink%7CGoogle%20Scholar"
                                            >Google Scholar</a
                                          >]</span
                                        >
                                      </span>
                                    </div>
                                  </div>
                                </div>
                              </div>
                              <!--post-content-->
                            </div>
                          </div>
                          <!-- Book content -->
                        </div>

                        <div id="rightcolumn" class="four_col col last">
                          <!-- Custom content above discovery portlets -->
                          <div class="col6"></div>

                          <div
                            xmlns:np="http://ncbi.gov/portal/XSLT/namespace"
                            xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                          >
                            <div class="format-menu">
                              <h2>Formats:</h2>
                              <ul>
                                <li class="selected">Article</li>
                                |
                                <li><a>PubReader</a></li>
                                |
                                <li class="epub-link"><a>ePub (beta)</a></li>
                                |
                                <li><a>PDF (466K)</a></li>
                                |
                                <li>
                                  <a
                                    data-citationid="PMC2597528"
                                    class="citationexporter ctxp"
                                    >Citation</a
                                  >
                                </li>
                              </ul>
                            </div>
                          </div>
                          <div
                            xmlns:np="http://ncbi.gov/portal/XSLT/namespace"
                            xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                            class="share-buttons"
                          >
                            <h2>Share</h2>
                            <ul>
                              <li class="facebook">
                                <a
                                  ><img src="" alt="Share on Facebook" />
                                  Facebook
                                </a>
                              </li>
                              <li class="twitter">
                                <a
                                  ><img src="" alt="Share on Twitter" />
                                  Twitter
                                </a>
                              </li>
                              <li class="gplus">
                                <a
                                  ><img src="" alt="Share on Google Plus" />
                                  Google+
                                </a>
                              </li>
                            </ul>
                          </div>

                          <div
                            id="ajax-portlets"
                            data-pmid="16637665"
                            data-aiid="2597528"
                            data-aid="2597528"
                            data-iid="174319"
                            data-domainid="319"
                            data-domain="nihpa"
                            data-accid="PMC2597528"
                            data-md5="71935435cbd79cbb33c3e3486a607b38"
                          ></div>

                          <!-- Custom content below discovery portlets -->
                          <div class="col7"></div>
                        </div>
                      </div>

                      <!-- Custom content after all -->
                      <div class="col8"></div>
                      <div class="col9"></div>

                      <div id="body-link-poppers"></div>
                    </div>
                    <div class="bottom">
                      <div id="NCBIFooter_dynamic">
                        <a id="help-desk-link" class="help_desk" target="_blank"
                          >Support Center</a
                        >
                        <a id="help-desk-link" class="help_desk" target="_blank"
                          >Support Center</a
                        >
                      </div>

                      <div class="footer" id="footer">
                        <div class="subfooter"></div>
                        <div id="external-disclaimer" class="offscreen_noflow">
                          External link. Please review our
                          <a>privacy policy</a>.
                        </div>
                        <div id="ncbifooter" class="contact_info">
                          <div id="footer-contents-right">
                            <div id="nlm_thumb_logo">
                              <a title="NLM">NLM</a>
                            </div>
                            <div id="nih_thumb_logo">
                              <a title="NIH">NIH</a>
                            </div>
                            <div id="hhs_thumb_logo">
                              <a title="DHHS">DHHS</a>
                            </div>
                            <div id="usagov_thumb_logo">
                              <a title="USA.gov">USA.gov</a>
                            </div>
                          </div>

                          <div id="footer-contents-left">
                            <p class="address vcard">
                              <span class="url">
                                <a class="fn url newdomain"
                                  >National Center for Biotechnology
                                  Information</a
                                >,
                              </span>
                              <span class="org url newdomain"
                                ><a>U.S. National Library of Medicine</a>
                              </span>
                              <span class="adr">
                                <span class="street-address"
                                  >8600 Rockville Pike</span
                                >, <span class="locality">Bethesda</span>
                                <span class="region">MD</span>,
                                <span class="postal-code">20894</span>
                                <span class="country-name">USA</span>
                              </span>
                            </p>

                            <a>Policies and Guidelines</a> | <a>Contact</a>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <!--/.page-->
                </div>
                <!--/.wrap-->
              </div>
              <!-- /.twelve_col -->
            </div>
            <!-- /.grid -->

            <span class="PAFAppResources"></span>

            <!-- BESelector tab -->

            <noscript><img alt="statistics" src="" /> </noscript>

            <!-- usually for JS scripts at page bottom -->
            <!--<component id="PageFixtures" label="styles"></component>-->

            <!-- 8A1A91EAF443B0D1_2120SID /projects/PMC/PMCViewer@4.46 ptpmc102 v4.1.r585844 Mon, May 06 2019 02:53:16 -->
          </body>
        </div>
      </div>
      <div class="footer-placeholder"></div>
    </el-main>

    <div class="footer" v-if="true">
      <div class="mark-history">
        <el-tag
          class="tags"
          v-for="tag in tags"
          :c-id="tag.id"
          :key="tag.id"
          :color="tag.color"
          @close="removeTags"
        >
          {{ tag.name }}
        </el-tag>
      </div>
    </div>
  </el-container>
</template>

<script>
export default {
  data: function () {
    return {
      tags: [],
      options: [{
        value: 'AptamerType',
        label: 'AptamerType',
        color: '#FFFFCC',
        type: 'T'
      }, {
        value: 'AptamerName',
        label: 'AptamerName',
        color: '#CCFFFF',
        type: 'T'
      }, {
        value: 'Sample',
        label: 'Sample',
        color: '#FFCCCC',
        type: 'T'
      }, {
        value: 'Target',
        label: 'Target',
        type: 'T',
        children: [{
          value: 'Protein',
          label: 'Protein',
          color: '#99CCCC',
          type: 'A'
        }, {
          value: 'Compound',
          label: 'Compound',
          color: '#FFCC99',
          type: 'A'
        }, {
          value: 'Virus',
          label: 'Virus',
          color: '#FF9999',
          type: 'A'
        }, {
          value: 'Cells',
          label: 'Cells',
          color: '#996699',
          type: 'A'
        }, {
          value: 'Ion',
          label: 'Ion',
          color: '#CC9999',
          type: 'A'
        }, {
          value: 'Other',
          label: 'Other',
          color: '#CCCC99',
          type: 'A'
        }]
      }, {
        value: 'Affinity',
        label: 'Affinity',
        color: '#FFFF99',
        type: 'T'
      }, {
        value: 'Sequence',
        label: 'Sequence',
        color: '#CCCCFF',
        type: 'T'
      }, {
        value: 'ScreenMethod',
        label: 'ScreenMethod',
        color: '#0099CC',
        type: 'T'
      }, {
        value: 'ScreenCondition',
        label: 'ScreenCondition',
        color: '#CCCCCC',
        type: 'T'
      }, {
        value: 'BindingBuffer',
        label: 'BindingBuffer',
        color: '#FF6666',
        type: 'T'
      }, {
        value: 'Application',
        label: 'Application',
        color: '#FF9966',
        type: 'T'
      }, {
        value: 'References',
        label: 'References',
        color: '#CC9966',
        type: 'T'
      }]
    }
  },
  mounted () {
    // 检查标签，重组tags
  },
  methods: {
    getCascaderObj (val, opt) {
      return val.map(function (value, index, array) {
        for (var itm of opt) {
          if (itm.value === value) {
            opt = itm.children
            return itm
          }
        }
        return null
      })
    },
    addTags () {
      // 获取class 为 tagger 标签
      // 转数组
      // 按照id去重
      // 根据Attribute 生成
      // var tagElements = document.getElementsByClassName('tagged')

      // if (tags.length) {
      //   this.tags.push({
      //     id: this.taggedNum,
      //     name: tags.map(s => s.label).join('/'),
      //     color: tags[1] ? tags[1].color : tags[0].color
      //   })
      // } else {
      //   this.tags.push({
      //     id: this.taggedNum,
      //     name: this.textarea,
      //     color: 'yellow'
      //   })
      // }
    }
  }
}
</script>

<style lang="less" scoped>
  ::selection {
    color: red;
    background: yellow;
  }

  .index-container {
    position: relative;
    .article {
      .one {
        border: 1px solid rgb(204, 45, 45);
      }
      .two {
        border: 1px solid rgb(162, 204, 45);
      }
      .three {
        border: 1px solid rgb(45, 74, 204);
      }
    }

    .footer {
      position: fixed;
      height: 300px;
      width: 100%;
      bottom: 0px;
      // box-shadow: 0 2px 4px rgba(0, 0, 0, 0.12), 0 0 6px rgba(0, 0, 0, 0.04);
      box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
      background-color: #fff;

      .mark-history {
        height: 220px;
        border-bottom: 1px solid rgba(0, 0, 0, 0.1);
        padding: 1rem;

        .tags {
          margin: 5px;
        }
      }

      .btns {
        position: absolute;
        bottom: 10px;
        // border-top: 1px solid rgba(0, 0, 0, 0.1);
        padding: 1rem;
      }
    }

    .footer-placeholder {
      height: 300px;
      width: 100%;
      // border: 1px solid rgb(236, 12, 150);
    }
  }
</style>

<style lang="less">
  .el-dialog__body {
    text-align: inherit !important;
  }
</style>
