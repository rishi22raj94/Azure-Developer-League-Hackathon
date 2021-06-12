using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace covid19_wld.Models.CovidStatus
{
    public class StateWiseDailyCovidCasesData
    {
        public partial class StatewiseInfo
        {
            [JsonProperty("AN")]
            public An An { get; set; }

            [JsonProperty("AP")]
            public Ap Ap { get; set; }

            [JsonProperty("AR")]
            public Ar Ar { get; set; }

            [JsonProperty("AS")]
            public As As { get; set; }

            [JsonProperty("BR")]
            public Br Br { get; set; }

            [JsonProperty("CH")]
            public Ch Ch { get; set; }

            [JsonProperty("CT")]
            public Ct Ct { get; set; }

            [JsonProperty("DL")]
            public Dl Dl { get; set; }

            [JsonProperty("DN")]
            public Dn Dn { get; set; }

            [JsonProperty("GA")]
            public An Ga { get; set; }

            [JsonProperty("GJ")]
            public Gj Gj { get; set; }

            [JsonProperty("HP")]
            public Hp Hp { get; set; }

            [JsonProperty("HR")]
            public Hr Hr { get; set; }

            [JsonProperty("JH")]
            public Jh Jh { get; set; }

            [JsonProperty("JK")]
            public Jk Jk { get; set; }

            [JsonProperty("KA")]
            public Ka Ka { get; set; }

            [JsonProperty("KL")]
            public Kl Kl { get; set; }

            [JsonProperty("LA")]
            public La La { get; set; }

            [JsonProperty("LD")]
            public Ld Ld { get; set; }

            [JsonProperty("MH")]
            public Mh Mh { get; set; }

            [JsonProperty("ML")]
            public Ml Ml { get; set; }

            [JsonProperty("MN")]
            public An Mn { get; set; }

            [JsonProperty("MP")]
            public Mp Mp { get; set; }

            [JsonProperty("MZ")]
            public Mz Mz { get; set; }

            [JsonProperty("NL")]
            public Nl Nl { get; set; }

            [JsonProperty("OR")]
            public Or Or { get; set; }

            [JsonProperty("PB")]
            public Pb Pb { get; set; }

            [JsonProperty("PY")]
            public Py Py { get; set; }

            [JsonProperty("RJ")]
            public Rj Rj { get; set; }

            [JsonProperty("SK")]
            public An Sk { get; set; }

            [JsonProperty("TG")]
            public An Tg { get; set; }

            [JsonProperty("TN")]
            public Tn Tn { get; set; }

            [JsonProperty("TR")]
            public Tr Tr { get; set; }

            [JsonProperty("TT")]
            public Tt Tt { get; set; }

            [JsonProperty("UP")]
            public Up Up { get; set; }

            [JsonProperty("UT")]
            public Ut Ut { get; set; }

            [JsonProperty("WB")]
            public Wb Wb { get; set; }
        }

        public partial class An
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public AnDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class PurpleDelta
        {
            [JsonProperty("confirmed")]
            public long Confirmed { get; set; }

            [JsonProperty("deceased", NullValueHandling = NullValueHandling.Ignore)]
            public long? Deceased { get; set; }

            [JsonProperty("recovered", NullValueHandling = NullValueHandling.Ignore)]
            public long? Recovered { get; set; }

            [JsonProperty("tested", NullValueHandling = NullValueHandling.Ignore)]
            public long? Tested { get; set; }

            [JsonProperty("other", NullValueHandling = NullValueHandling.Ignore)]
            public long? Other { get; set; }

            [JsonProperty("vaccinated", NullValueHandling = NullValueHandling.Ignore)]
            public long? Vaccinated { get; set; }
        }

        public partial class AnDistricts
        {
            [JsonProperty("Unknown")]
            public Unknown Unknown { get; set; }
        }

        public partial class Unknown
        {
            [JsonProperty("delta", NullValueHandling = NullValueHandling.Ignore)]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public UnknownMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class UnknownMeta
        {
            [JsonProperty("tested")]
            public Ted Tested { get; set; }
        }

        public partial class Ted
        {
            [JsonProperty("last_updated")]
            public DateTimeOffset LastUpdated { get; set; }

            [JsonProperty("source")]
            public Uri Source { get; set; }
        }

        public partial class AnMeta
        {
            [JsonProperty("last_updated")]
            public DateTimeOffset LastUpdated { get; set; }

            [JsonProperty("population")]
            public long Population { get; set; }

            [JsonProperty("tested")]
            public Ted Tested { get; set; }

            [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
            public string Notes { get; set; }

            [JsonProperty("vaccinated", NullValueHandling = NullValueHandling.Ignore)]
            public Ted Vaccinated { get; set; }
        }

        public partial class Ap
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public ApDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class ApDistricts
        {
            [JsonProperty("Anantapur")]
            public Anantapur Anantapur { get; set; }

            [JsonProperty("Chittoor")]
            public Anantapur Chittoor { get; set; }

            [JsonProperty("East Godavari")]
            public Anantapur EastGodavari { get; set; }

            [JsonProperty("Foreign Evacuees")]
            public ForeignEvacuees ForeignEvacuees { get; set; }

            [JsonProperty("Guntur")]
            public Anantapur Guntur { get; set; }

            [JsonProperty("Krishna")]
            public Anantapur Krishna { get; set; }

            [JsonProperty("Kurnool")]
            public Anantapur Kurnool { get; set; }

            [JsonProperty("Other State")]
            public ForeignEvacuees OtherState { get; set; }

            [JsonProperty("Prakasam")]
            public Anantapur Prakasam { get; set; }

            [JsonProperty("S.P.S. Nellore")]
            public Anantapur SPSNellore { get; set; }

            [JsonProperty("Srikakulam")]
            public Anantapur Srikakulam { get; set; }

            [JsonProperty("Visakhapatnam")]
            public Anantapur Visakhapatnam { get; set; }

            [JsonProperty("Vizianagaram")]
            public Anantapur Vizianagaram { get; set; }

            [JsonProperty("West Godavari")]
            public Anantapur WestGodavari { get; set; }

            [JsonProperty("Y.S.R. Kadapa")]
            public Anantapur YSRKadapa { get; set; }
        }

        public partial class Anantapur
        {
            [JsonProperty("delta", NullValueHandling = NullValueHandling.Ignore)]
            public AnantapurDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnantapurMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class AnantapurDelta
        {
            [JsonProperty("confirmed")]
            public long Confirmed { get; set; }

            [JsonProperty("deceased", NullValueHandling = NullValueHandling.Ignore)]
            public long? Deceased { get; set; }

            [JsonProperty("recovered", NullValueHandling = NullValueHandling.Ignore)]
            public long? Recovered { get; set; }
        }

        public partial class AnantapurMeta
        {
            [JsonProperty("population")]
            public long Population { get; set; }

            [JsonProperty("tested")]
            public Tested Tested { get; set; }
        }

        public partial class Tested
        {
            [JsonProperty("last_updated")]
            public DateTimeOffset LastUpdated { get; set; }
        }

        public partial class ForeignEvacuees
        {
            [JsonProperty("total")]
            public ForeignEvacueesDelta Total { get; set; }
        }

        public partial class ForeignEvacueesDelta
        {
            [JsonProperty("confirmed", NullValueHandling = NullValueHandling.Ignore)]
            public long? Confirmed { get; set; }

            [JsonProperty("recovered", NullValueHandling = NullValueHandling.Ignore)]
            public long? Recovered { get; set; }
        }

        public partial class Ar
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public ArDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class ArDistricts
        {
            [JsonProperty("Anjaw")]
            public Anjaw Anjaw { get; set; }

            [JsonProperty("Capital Complex")]
            public CapitalComplex CapitalComplex { get; set; }

            [JsonProperty("Changlang")]
            public Changlang Changlang { get; set; }

            [JsonProperty("East Kameng")]
            public Anjaw EastKameng { get; set; }

            [JsonProperty("East Siang")]
            public Anantapur EastSiang { get; set; }

            [JsonProperty("Kamle")]
            public Anjaw Kamle { get; set; }

            [JsonProperty("Kra Daadi")]
            public KraDaadi KraDaadi { get; set; }

            [JsonProperty("Kurung Kumey")]
            public KurungKumey KurungKumey { get; set; }

            [JsonProperty("Lepa Rada")]
            public KraDaadi LepaRada { get; set; }

            [JsonProperty("Lohit")]
            public Anantapur Lohit { get; set; }

            [JsonProperty("Longding")]
            public Anjaw Longding { get; set; }

            [JsonProperty("Lower Dibang Valley")]
            public Anantapur LowerDibangValley { get; set; }

            [JsonProperty("Lower Siang")]
            public Anjaw LowerSiang { get; set; }

            [JsonProperty("Lower Subansiri")]
            public Anantapur LowerSubansiri { get; set; }

            [JsonProperty("Namsai")]
            public Anantapur Namsai { get; set; }

            [JsonProperty("Pakke Kessang")]
            public KraDaadi PakkeKessang { get; set; }

            [JsonProperty("Papum Pare")]
            public Anantapur PapumPare { get; set; }

            [JsonProperty("Shi Yomi")]
            public KurungKumey ShiYomi { get; set; }

            [JsonProperty("Siang")]
            public Changlang Siang { get; set; }

            [JsonProperty("Tawang")]
            public Anantapur Tawang { get; set; }

            [JsonProperty("Tirap")]
            public Changlang Tirap { get; set; }

            [JsonProperty("Upper Dibang Valley")]
            public Anantapur UpperDibangValley { get; set; }

            [JsonProperty("Upper Siang")]
            public Anjaw UpperSiang { get; set; }

            [JsonProperty("Upper Subansiri")]
            public Changlang UpperSubansiri { get; set; }

            [JsonProperty("West Kameng")]
            public Changlang WestKameng { get; set; }

            [JsonProperty("West Siang")]
            public Changlang WestSiang { get; set; }
        }

        public partial class Anjaw
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnantapurMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class CapitalComplex
        {
            [JsonProperty("meta")]
            public CapitalComplexMeta Meta { get; set; }

            [JsonProperty("total")]
            public CapitalComplexDelta Total { get; set; }
        }

        public partial class CapitalComplexMeta
        {
            [JsonProperty("tested")]
            public Tested Tested { get; set; }
        }

        public partial class CapitalComplexDelta
        {
            [JsonProperty("tested")]
            public long Tested { get; set; }
        }

        public partial class Changlang
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnantapurMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }

            [JsonProperty("delta", NullValueHandling = NullValueHandling.Ignore)]
            public ForeignEvacueesDelta Delta { get; set; }
        }

        public partial class KraDaadi
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public CapitalComplexMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class KurungKumey
        {
            [JsonProperty("delta7")]
            public Delta7 Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnantapurMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Delta7
        {
            [JsonProperty("confirmed")]
            public long Confirmed { get; set; }

            [JsonProperty("vaccinated")]
            public long Vaccinated { get; set; }
        }

        public partial class As
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public AnDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Br
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public BrDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class BrDistricts
        {
            [JsonProperty("Araria")]
            public Anantapur Araria { get; set; }

            [JsonProperty("Arwal")]
            public Anantapur Arwal { get; set; }

            [JsonProperty("Aurangabad")]
            public Changlang Aurangabad { get; set; }

            [JsonProperty("Banka")]
            public Anantapur Banka { get; set; }

            [JsonProperty("Begusarai")]
            public Anantapur Begusarai { get; set; }

            [JsonProperty("Bhagalpur")]
            public Anantapur Bhagalpur { get; set; }

            [JsonProperty("Bhojpur")]
            public Anantapur Bhojpur { get; set; }

            [JsonProperty("Buxar")]
            public Anantapur Buxar { get; set; }

            [JsonProperty("Darbhanga")]
            public Anantapur Darbhanga { get; set; }

            [JsonProperty("East Champaran")]
            public Anantapur EastChamparan { get; set; }

            [JsonProperty("Gaya")]
            public Anantapur Gaya { get; set; }

            [JsonProperty("Gopalganj")]
            public Anantapur Gopalganj { get; set; }

            [JsonProperty("Jamui")]
            public Anantapur Jamui { get; set; }

            [JsonProperty("Jehanabad")]
            public Anantapur Jehanabad { get; set; }

            [JsonProperty("Kaimur")]
            public Anantapur Kaimur { get; set; }

            [JsonProperty("Katihar")]
            public Anantapur Katihar { get; set; }

            [JsonProperty("Khagaria")]
            public Anantapur Khagaria { get; set; }

            [JsonProperty("Kishanganj")]
            public Anantapur Kishanganj { get; set; }

            [JsonProperty("Lakhisarai")]
            public Anantapur Lakhisarai { get; set; }

            [JsonProperty("Madhepura")]
            public Anantapur Madhepura { get; set; }

            [JsonProperty("Madhubani")]
            public Anantapur Madhubani { get; set; }

            [JsonProperty("Munger")]
            public Anantapur Munger { get; set; }

            [JsonProperty("Muzaffarpur")]
            public Anantapur Muzaffarpur { get; set; }

            [JsonProperty("Nalanda")]
            public Anantapur Nalanda { get; set; }

            [JsonProperty("Nawada")]
            public Anantapur Nawada { get; set; }

            [JsonProperty("Patna")]
            public Anantapur Patna { get; set; }

            [JsonProperty("Purnia")]
            public Anantapur Purnia { get; set; }

            [JsonProperty("Rohtas")]
            public Anantapur Rohtas { get; set; }

            [JsonProperty("Saharsa")]
            public Anantapur Saharsa { get; set; }

            [JsonProperty("Samastipur")]
            public Anantapur Samastipur { get; set; }

            [JsonProperty("Saran")]
            public Anantapur Saran { get; set; }

            [JsonProperty("Sheikhpura")]
            public Anantapur Sheikhpura { get; set; }

            [JsonProperty("Sheohar")]
            public Anantapur Sheohar { get; set; }

            [JsonProperty("Sitamarhi")]
            public Anantapur Sitamarhi { get; set; }

            [JsonProperty("Siwan")]
            public Anantapur Siwan { get; set; }

            [JsonProperty("Supaul")]
            public Anantapur Supaul { get; set; }

            [JsonProperty("Vaishali")]
            public Vaishali Vaishali { get; set; }

            [JsonProperty("West Champaran")]
            public Anantapur WestChamparan { get; set; }
        }

        public partial class Vaishali
        {
            [JsonProperty("delta")]
            public ForeignEvacueesDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnantapurMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Ch
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public ChDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class ChDistricts
        {
            [JsonProperty("Chandigarh")]
            public Chandigarh Chandigarh { get; set; }
        }

        public partial class Chandigarh
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public ChandigarhMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class ChandigarhMeta
        {
            [JsonProperty("population")]
            public long Population { get; set; }

            [JsonProperty("tested")]
            public Ted Tested { get; set; }
        }

        public partial class Ct
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public CtDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class CtDistricts
        {
            [JsonProperty("Balod")]
            public Anantapur Balod { get; set; }

            [JsonProperty("Baloda Bazar")]
            public Anantapur BalodaBazar { get; set; }

            [JsonProperty("Balrampur")]
            public Anantapur Balrampur { get; set; }

            [JsonProperty("Bametara")]
            public Anantapur Bametara { get; set; }

            [JsonProperty("Bastar")]
            public Anantapur Bastar { get; set; }

            [JsonProperty("Bijapur")]
            public Anantapur Bijapur { get; set; }

            [JsonProperty("Bilaspur")]
            public Anantapur Bilaspur { get; set; }

            [JsonProperty("Dakshin Bastar Dantewada")]
            public Changlang DakshinBastarDantewada { get; set; }

            [JsonProperty("Dhamtari")]
            public Anantapur Dhamtari { get; set; }

            [JsonProperty("Durg")]
            public Anantapur Durg { get; set; }

            [JsonProperty("Gariaband")]
            public Anantapur Gariaband { get; set; }

            [JsonProperty("Gaurela Pendra Marwahi")]
            public GaurelaPendraMarwahi GaurelaPendraMarwahi { get; set; }

            [JsonProperty("Janjgir Champa")]
            public Anantapur JanjgirChampa { get; set; }

            [JsonProperty("Jashpur")]
            public Anantapur Jashpur { get; set; }

            [JsonProperty("Kabeerdham")]
            public Anantapur Kabeerdham { get; set; }

            [JsonProperty("Kondagaon")]
            public Anantapur Kondagaon { get; set; }

            [JsonProperty("Korba")]
            public Anantapur Korba { get; set; }

            [JsonProperty("Koriya")]
            public Anantapur Koriya { get; set; }

            [JsonProperty("Mahasamund")]
            public Anantapur Mahasamund { get; set; }

            [JsonProperty("Mungeli")]
            public Anantapur Mungeli { get; set; }

            [JsonProperty("Narayanpur")]
            public Changlang Narayanpur { get; set; }

            [JsonProperty("Other State")]
            public PurpleOtherState OtherState { get; set; }

            [JsonProperty("Raigarh")]
            public Anantapur Raigarh { get; set; }

            [JsonProperty("Raipur")]
            public Anantapur Raipur { get; set; }

            [JsonProperty("Rajnandgaon")]
            public Anantapur Rajnandgaon { get; set; }

            [JsonProperty("Sukma")]
            public Anantapur Sukma { get; set; }

            [JsonProperty("Surajpur")]
            public Anantapur Surajpur { get; set; }

            [JsonProperty("Surguja")]
            public Anantapur Surguja { get; set; }

            [JsonProperty("Uttar Bastar Kanker")]
            public Anantapur UttarBastarKanker { get; set; }
        }

        public partial class GaurelaPendraMarwahi
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public CapitalComplexMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class PurpleOtherState
        {
            [JsonProperty("delta")]
            public FluffyDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class FluffyDelta
        {
            [JsonProperty("deceased")]
            public long Deceased { get; set; }
        }

        public partial class Dl
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public DlDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class DlDistricts
        {
            [JsonProperty("Delhi")]
            public Chandigarh Delhi { get; set; }
        }

        public partial class Dn
        {
            [JsonProperty("delta")]
            public ForeignEvacueesDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public DnDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class DnDistricts
        {
            [JsonProperty("Dadra and Nagar Haveli")]
            public Vaishali DadraAndNagarHaveli { get; set; }

            [JsonProperty("Daman")]
            public Vaishali Daman { get; set; }

            [JsonProperty("Diu")]
            public Diu Diu { get; set; }
        }

        public partial class Diu
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnantapurMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }

            [JsonProperty("delta", NullValueHandling = NullValueHandling.Ignore)]
            public DiuDelta Delta { get; set; }
        }

        public partial class DiuDelta
        {
            [JsonProperty("confirmed")]
            public long Confirmed { get; set; }

            [JsonProperty("other", NullValueHandling = NullValueHandling.Ignore)]
            public long? Other { get; set; }

            [JsonProperty("recovered")]
            public long Recovered { get; set; }
        }

        public partial class Gj
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public GjDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class GjDistricts
        {
            [JsonProperty("Ahmedabad")]
            public Anantapur Ahmedabad { get; set; }

            [JsonProperty("Amreli")]
            public Anantapur Amreli { get; set; }

            [JsonProperty("Anand")]
            public Anantapur Anand { get; set; }

            [JsonProperty("Aravalli")]
            public Anantapur Aravalli { get; set; }

            [JsonProperty("Banaskantha")]
            public Anantapur Banaskantha { get; set; }

            [JsonProperty("Bharuch")]
            public Anantapur Bharuch { get; set; }

            [JsonProperty("Bhavnagar")]
            public Anantapur Bhavnagar { get; set; }

            [JsonProperty("Botad")]
            public Anantapur Botad { get; set; }

            [JsonProperty("Chhota Udaipur")]
            public Anantapur ChhotaUdaipur { get; set; }

            [JsonProperty("Dahod")]
            public Anantapur Dahod { get; set; }

            [JsonProperty("Dang")]
            public Anantapur Dang { get; set; }

            [JsonProperty("Devbhumi Dwarka")]
            public Anantapur DevbhumiDwarka { get; set; }

            [JsonProperty("Gandhinagar")]
            public Anantapur Gandhinagar { get; set; }

            [JsonProperty("Gir Somnath")]
            public Anantapur GirSomnath { get; set; }

            [JsonProperty("Jamnagar")]
            public Anantapur Jamnagar { get; set; }

            [JsonProperty("Junagadh")]
            public Anantapur Junagadh { get; set; }

            [JsonProperty("Kheda")]
            public Anantapur Kheda { get; set; }

            [JsonProperty("Kutch")]
            public Anantapur Kutch { get; set; }

            [JsonProperty("Mahisagar")]
            public Anantapur Mahisagar { get; set; }

            [JsonProperty("Mehsana")]
            public Anantapur Mehsana { get; set; }

            [JsonProperty("Morbi")]
            public Anantapur Morbi { get; set; }

            [JsonProperty("Narmada")]
            public Anantapur Narmada { get; set; }

            [JsonProperty("Navsari")]
            public Anantapur Navsari { get; set; }

            [JsonProperty("Other State")]
            public FluffyOtherState OtherState { get; set; }

            [JsonProperty("Panchmahal")]
            public Anantapur Panchmahal { get; set; }

            [JsonProperty("Patan")]
            public Anantapur Patan { get; set; }

            [JsonProperty("Porbandar")]
            public Anantapur Porbandar { get; set; }

            [JsonProperty("Rajkot")]
            public Anantapur Rajkot { get; set; }

            [JsonProperty("Sabarkantha")]
            public Anantapur Sabarkantha { get; set; }

            [JsonProperty("Surat")]
            public Anantapur Surat { get; set; }

            [JsonProperty("Surendranagar")]
            public Anantapur Surendranagar { get; set; }

            [JsonProperty("Tapi")]
            public Anantapur Tapi { get; set; }

            [JsonProperty("Vadodara")]
            public Anantapur Vadodara { get; set; }

            [JsonProperty("Valsad")]
            public Anantapur Valsad { get; set; }
        }

        public partial class FluffyOtherState
        {
            [JsonProperty("meta")]
            public CapitalComplexMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Hp
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public HpDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class HpDistricts
        {
            [JsonProperty("Bilaspur")]
            public Bilaspur Bilaspur { get; set; }

            [JsonProperty("Chamba")]
            public Chamba Chamba { get; set; }

            [JsonProperty("Hamirpur")]
            public Bilaspur Hamirpur { get; set; }

            [JsonProperty("Kangra")]
            public Chamba Kangra { get; set; }

            [JsonProperty("Kinnaur")]
            public Anantapur Kinnaur { get; set; }

            [JsonProperty("Kullu")]
            public Bilaspur Kullu { get; set; }

            [JsonProperty("Lahaul and Spiti")]
            public Anantapur LahaulAndSpiti { get; set; }

            [JsonProperty("Mandi")]
            public Anantapur Mandi { get; set; }

            [JsonProperty("Shimla")]
            public Chamba Shimla { get; set; }

            [JsonProperty("Sirmaur")]
            public Anantapur Sirmaur { get; set; }

            [JsonProperty("Solan")]
            public Anantapur Solan { get; set; }

            [JsonProperty("Una")]
            public Bilaspur Una { get; set; }
        }

        public partial class Bilaspur
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnantapurMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Chamba
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public ChambaMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class ChambaMeta
        {
            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("population")]
            public long Population { get; set; }

            [JsonProperty("tested")]
            public Tested Tested { get; set; }

            [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
            public DateTimeOffset? LastUpdated { get; set; }
        }

        public partial class Hr
        {
            [JsonProperty("delta")]
            public CapitalComplexDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public Dictionary<string, Anantapur> Districts { get; set; }

            [JsonProperty("meta")]
            public HrMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class HrMeta
        {
            [JsonProperty("last_updated")]
            public DateTimeOffset LastUpdated { get; set; }

            [JsonProperty("population")]
            public long Population { get; set; }

            [JsonProperty("tested")]
            public Tested Tested { get; set; }
        }

        public partial class Jh
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public JhDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class JhDistricts
        {
            [JsonProperty("Bokaro")]
            public Anantapur Bokaro { get; set; }

            [JsonProperty("Chatra")]
            public Chatra Chatra { get; set; }

            [JsonProperty("Deoghar")]
            public Anantapur Deoghar { get; set; }

            [JsonProperty("Dhanbad")]
            public Chatra Dhanbad { get; set; }

            [JsonProperty("Dumka")]
            public Anantapur Dumka { get; set; }

            [JsonProperty("East Singhbhum")]
            public Chatra EastSinghbhum { get; set; }

            [JsonProperty("Garhwa")]
            public Chatra Garhwa { get; set; }

            [JsonProperty("Giridih")]
            public Anantapur Giridih { get; set; }

            [JsonProperty("Godda")]
            public Anantapur Godda { get; set; }

            [JsonProperty("Gumla")]
            public Chatra Gumla { get; set; }

            [JsonProperty("Hazaribagh")]
            public Chatra Hazaribagh { get; set; }

            [JsonProperty("Jamtara")]
            public Anantapur Jamtara { get; set; }

            [JsonProperty("Khunti")]
            public Anantapur Khunti { get; set; }

            [JsonProperty("Koderma")]
            public Chatra Koderma { get; set; }

            [JsonProperty("Latehar")]
            public Chatra Latehar { get; set; }

            [JsonProperty("Lohardaga")]
            public Anantapur Lohardaga { get; set; }

            [JsonProperty("Pakur")]
            public Changlang Pakur { get; set; }

            [JsonProperty("Palamu")]
            public Chatra Palamu { get; set; }

            [JsonProperty("Ramgarh")]
            public Chatra Ramgarh { get; set; }

            [JsonProperty("Ranchi")]
            public Chatra Ranchi { get; set; }

            [JsonProperty("Sahibganj")]
            public Anantapur Sahibganj { get; set; }

            [JsonProperty("Saraikela-Kharsawan")]
            public Anantapur SaraikelaKharsawan { get; set; }

            [JsonProperty("Simdega")]
            public Chatra Simdega { get; set; }

            [JsonProperty("West Singhbhum")]
            public Chatra WestSinghbhum { get; set; }
        }

        public partial class Chatra
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            public ChatraMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }

            [JsonProperty("delta", NullValueHandling = NullValueHandling.Ignore)]
            public AnantapurDelta Delta { get; set; }
        }

        public partial class ChatraMeta
        {
            [JsonProperty("population")]
            public long Population { get; set; }
        }

        public partial class Jk
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public JkDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class JkDistricts
        {
            [JsonProperty("Anantnag")]
            public Chatra Anantnag { get; set; }

            [JsonProperty("Bandipora")]
            public Chatra Bandipora { get; set; }

            [JsonProperty("Baramulla")]
            public Chatra Baramulla { get; set; }

            [JsonProperty("Budgam")]
            public Chatra Budgam { get; set; }

            [JsonProperty("Doda")]
            public Chatra Doda { get; set; }

            [JsonProperty("Ganderbal")]
            public Chatra Ganderbal { get; set; }

            [JsonProperty("Jammu")]
            public Chatra Jammu { get; set; }

            [JsonProperty("Kathua")]
            public Chatra Kathua { get; set; }

            [JsonProperty("Kishtwar")]
            public Chatra Kishtwar { get; set; }

            [JsonProperty("Kulgam")]
            public Chatra Kulgam { get; set; }

            [JsonProperty("Kupwara")]
            public Chatra Kupwara { get; set; }

            [JsonProperty("Pulwama")]
            public Anantapur Pulwama { get; set; }

            [JsonProperty("Punch")]
            public Chatra Punch { get; set; }

            [JsonProperty("Rajouri")]
            public Chatra Rajouri { get; set; }

            [JsonProperty("Ramban")]
            public Chatra Ramban { get; set; }

            [JsonProperty("Reasi")]
            public Chatra Reasi { get; set; }

            [JsonProperty("Samba")]
            public Chatra Samba { get; set; }

            [JsonProperty("Shopiyan")]
            public Chatra Shopiyan { get; set; }

            [JsonProperty("Srinagar")]
            public Chatra Srinagar { get; set; }

            [JsonProperty("Udhampur")]
            public Chatra Udhampur { get; set; }
        }

        public partial class Ka
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public KaDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class KaDistricts
        {
            [JsonProperty("Bagalkote")]
            public Anantapur Bagalkote { get; set; }

            [JsonProperty("Ballari")]
            public Anantapur Ballari { get; set; }

            [JsonProperty("Belagavi")]
            public Anantapur Belagavi { get; set; }

            [JsonProperty("Bengaluru Rural")]
            public Anantapur BengaluruRural { get; set; }

            [JsonProperty("Bengaluru Urban")]
            public Bilaspur BengaluruUrban { get; set; }

            [JsonProperty("Bidar")]
            public Bilaspur Bidar { get; set; }

            [JsonProperty("Chamarajanagara")]
            public Bilaspur Chamarajanagara { get; set; }

            [JsonProperty("Chikkaballapura")]
            public Bilaspur Chikkaballapura { get; set; }

            [JsonProperty("Chikkamagaluru")]
            public Anantapur Chikkamagaluru { get; set; }

            [JsonProperty("Chitradurga")]
            public Anantapur Chitradurga { get; set; }

            [JsonProperty("Dakshina Kannada")]
            public Bilaspur DakshinaKannada { get; set; }

            [JsonProperty("Davanagere")]
            public Anantapur Davanagere { get; set; }

            [JsonProperty("Dharwad")]
            public Bilaspur Dharwad { get; set; }

            [JsonProperty("Gadag")]
            public Anantapur Gadag { get; set; }

            [JsonProperty("Hassan")]
            public Bilaspur Hassan { get; set; }

            [JsonProperty("Haveri")]
            public Anantapur Haveri { get; set; }

            [JsonProperty("Kalaburagi")]
            public Anantapur Kalaburagi { get; set; }

            [JsonProperty("Kodagu")]
            public Anantapur Kodagu { get; set; }

            [JsonProperty("Kolar")]
            public Anantapur Kolar { get; set; }

            [JsonProperty("Koppal")]
            public Anantapur Koppal { get; set; }

            [JsonProperty("Mandya")]
            public Anantapur Mandya { get; set; }

            [JsonProperty("Mysuru")]
            public Anantapur Mysuru { get; set; }

            [JsonProperty("Other State")]
            public OtherState OtherState { get; set; }

            [JsonProperty("Raichur")]
            public Anantapur Raichur { get; set; }

            [JsonProperty("Ramanagara")]
            public Anantapur Ramanagara { get; set; }

            [JsonProperty("Shivamogga")]
            public Anantapur Shivamogga { get; set; }

            [JsonProperty("Tumakuru")]
            public Anantapur Tumakuru { get; set; }

            [JsonProperty("Udupi")]
            public Anantapur Udupi { get; set; }

            [JsonProperty("Uttara Kannada")]
            public Anantapur UttaraKannada { get; set; }

            [JsonProperty("Vijayapura")]
            public Anantapur Vijayapura { get; set; }

            [JsonProperty("Yadgir")]
            public Anantapur Yadgir { get; set; }
        }

        public partial class OtherState
        {
            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Kl
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public KlDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class KlDistricts
        {
            [JsonProperty("Alappuzha")]
            public Alappuzha Alappuzha { get; set; }

            [JsonProperty("Ernakulam")]
            public Alappuzha Ernakulam { get; set; }

            [JsonProperty("Idukki")]
            public Vaishali Idukki { get; set; }

            [JsonProperty("Kannur")]
            public Vaishali Kannur { get; set; }

            [JsonProperty("Kasaragod")]
            public Alappuzha Kasaragod { get; set; }

            [JsonProperty("Kollam")]
            public Alappuzha Kollam { get; set; }

            [JsonProperty("Kottayam")]
            public Alappuzha Kottayam { get; set; }

            [JsonProperty("Kozhikode")]
            public Bilaspur Kozhikode { get; set; }

            [JsonProperty("Malappuram")]
            public Bilaspur Malappuram { get; set; }

            [JsonProperty("Palakkad")]
            public Bilaspur Palakkad { get; set; }

            [JsonProperty("Pathanamthitta")]
            public Bilaspur Pathanamthitta { get; set; }

            [JsonProperty("Thiruvananthapuram")]
            public Bilaspur Thiruvananthapuram { get; set; }

            [JsonProperty("Thrissur")]
            public Bilaspur Thrissur { get; set; }

            [JsonProperty("Wayanad")]
            public Bilaspur Wayanad { get; set; }
        }

        public partial class Alappuzha
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public ChatraMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class La
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public LaDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class LaDistricts
        {
            [JsonProperty("Kargil")]
            public Anantapur Kargil { get; set; }

            [JsonProperty("Leh")]
            public Anantapur Leh { get; set; }
        }

        public partial class Ld
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public LdDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class LdDistricts
        {
            [JsonProperty("Lakshadweep")]
            public Lakshadweep Lakshadweep { get; set; }
        }

        public partial class Lakshadweep
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public ChandigarhMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Mh
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public MhDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class MhDistricts
        {
            [JsonProperty("Ahmednagar")]
            public Bilaspur Ahmednagar { get; set; }

            [JsonProperty("Akola")]
            public Alappuzha Akola { get; set; }

            [JsonProperty("Amravati")]
            public Alappuzha Amravati { get; set; }

            [JsonProperty("Aurangabad")]
            public Bilaspur Aurangabad { get; set; }

            [JsonProperty("Beed")]
            public Bilaspur Beed { get; set; }

            [JsonProperty("Bhandara")]
            public Bilaspur Bhandara { get; set; }

            [JsonProperty("Buldhana")]
            public Bilaspur Buldhana { get; set; }

            [JsonProperty("Chandrapur")]
            public Bilaspur Chandrapur { get; set; }

            [JsonProperty("Dhule")]
            public Bilaspur Dhule { get; set; }

            [JsonProperty("Gadchiroli")]
            public Bilaspur Gadchiroli { get; set; }

            [JsonProperty("Gondia")]
            public Bilaspur Gondia { get; set; }

            [JsonProperty("Hingoli")]
            public Anantapur Hingoli { get; set; }

            [JsonProperty("Jalgaon")]
            public Bilaspur Jalgaon { get; set; }

            [JsonProperty("Jalna")]
            public Bilaspur Jalna { get; set; }

            [JsonProperty("Kolhapur")]
            public Alappuzha Kolhapur { get; set; }

            [JsonProperty("Latur")]
            public Alappuzha Latur { get; set; }

            [JsonProperty("Mumbai")]
            public Chamba Mumbai { get; set; }

            [JsonProperty("Nagpur")]
            public Chamba Nagpur { get; set; }

            [JsonProperty("Nanded")]
            public Chamba Nanded { get; set; }

            [JsonProperty("Nandurbar")]
            public Vaishali Nandurbar { get; set; }

            [JsonProperty("Nashik")]
            public Chamba Nashik { get; set; }

            [JsonProperty("Osmanabad")]
            public Bilaspur Osmanabad { get; set; }

            [JsonProperty("Other State")]
            public OtherState OtherState { get; set; }

            [JsonProperty("Palghar")]
            public Bilaspur Palghar { get; set; }

            [JsonProperty("Parbhani")]
            public Bilaspur Parbhani { get; set; }

            [JsonProperty("Pune")]
            public Chamba Pune { get; set; }

            [JsonProperty("Raigad")]
            public Chamba Raigad { get; set; }

            [JsonProperty("Ratnagiri")]
            public Alappuzha Ratnagiri { get; set; }

            [JsonProperty("Sangli")]
            public Alappuzha Sangli { get; set; }

            [JsonProperty("Satara")]
            public Bilaspur Satara { get; set; }

            [JsonProperty("Sindhudurg")]
            public Alappuzha Sindhudurg { get; set; }

            [JsonProperty("Solapur")]
            public Bilaspur Solapur { get; set; }

            [JsonProperty("Thane")]
            public Bilaspur Thane { get; set; }

            [JsonProperty("Wardha")]
            public Bilaspur Wardha { get; set; }

            [JsonProperty("Washim")]
            public Alappuzha Washim { get; set; }

            [JsonProperty("Yavatmal")]
            public Bilaspur Yavatmal { get; set; }
        }

        public partial class Ml
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public Dictionary<string, Chatra> Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Mp
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public MpDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public ChambaMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class MpDistricts
        {
            [JsonProperty("Agar Malwa")]
            public Chatra AgarMalwa { get; set; }

            [JsonProperty("Alirajpur")]
            public Chatra Alirajpur { get; set; }

            [JsonProperty("Anuppur")]
            public Anantapur Anuppur { get; set; }

            [JsonProperty("Ashoknagar")]
            public Changlang Ashoknagar { get; set; }

            [JsonProperty("Balaghat")]
            public Anantapur Balaghat { get; set; }

            [JsonProperty("Barwani")]
            public Anantapur Barwani { get; set; }

            [JsonProperty("Betul")]
            public Anantapur Betul { get; set; }

            [JsonProperty("Bhind")]
            public Anantapur Bhind { get; set; }

            [JsonProperty("Bhopal")]
            public Anantapur Bhopal { get; set; }

            [JsonProperty("Burhanpur")]
            public Changlang Burhanpur { get; set; }

            [JsonProperty("Chhatarpur")]
            public Anantapur Chhatarpur { get; set; }

            [JsonProperty("Chhindwara")]
            public Anantapur Chhindwara { get; set; }

            [JsonProperty("Damoh")]
            public Anantapur Damoh { get; set; }

            [JsonProperty("Datia")]
            public Anantapur Datia { get; set; }

            [JsonProperty("Dewas")]
            public Changlang Dewas { get; set; }

            [JsonProperty("Dhar")]
            public Anantapur Dhar { get; set; }

            [JsonProperty("Dindori")]
            public Anantapur Dindori { get; set; }

            [JsonProperty("Guna")]
            public Changlang Guna { get; set; }

            [JsonProperty("Gwalior")]
            public Anantapur Gwalior { get; set; }

            [JsonProperty("Harda")]
            public Anantapur Harda { get; set; }

            [JsonProperty("Hoshangabad")]
            public Changlang Hoshangabad { get; set; }

            [JsonProperty("Indore")]
            public Anantapur Indore { get; set; }

            [JsonProperty("Jabalpur")]
            public Anantapur Jabalpur { get; set; }

            [JsonProperty("Jhabua")]
            public Anantapur Jhabua { get; set; }

            [JsonProperty("Katni")]
            public Anantapur Katni { get; set; }

            [JsonProperty("Khandwa")]
            public Anantapur Khandwa { get; set; }

            [JsonProperty("Khargone")]
            public Anantapur Khargone { get; set; }

            [JsonProperty("Mandla")]
            public Chatra Mandla { get; set; }

            [JsonProperty("Mandsaur")]
            public Anantapur Mandsaur { get; set; }

            [JsonProperty("Morena")]
            public Anantapur Morena { get; set; }

            [JsonProperty("Narsinghpur")]
            public Anantapur Narsinghpur { get; set; }

            [JsonProperty("Neemuch")]
            public Changlang Neemuch { get; set; }

            [JsonProperty("Niwari")]
            public Niwari Niwari { get; set; }

            [JsonProperty("Panna")]
            public Chatra Panna { get; set; }

            [JsonProperty("Raisen")]
            public Anantapur Raisen { get; set; }

            [JsonProperty("Rajgarh")]
            public Changlang Rajgarh { get; set; }

            [JsonProperty("Ratlam")]
            public Anantapur Ratlam { get; set; }

            [JsonProperty("Rewa")]
            public Anantapur Rewa { get; set; }

            [JsonProperty("Sagar")]
            public Anantapur Sagar { get; set; }

            [JsonProperty("Satna")]
            public Anantapur Satna { get; set; }

            [JsonProperty("Sehore")]
            public Changlang Sehore { get; set; }

            [JsonProperty("Seoni")]
            public Anantapur Seoni { get; set; }

            [JsonProperty("Shahdol")]
            public Anantapur Shahdol { get; set; }

            [JsonProperty("Shajapur")]
            public Anantapur Shajapur { get; set; }

            [JsonProperty("Sheopur")]
            public Anantapur Sheopur { get; set; }

            [JsonProperty("Shivpuri")]
            public Anantapur Shivpuri { get; set; }

            [JsonProperty("Sidhi")]
            public Anantapur Sidhi { get; set; }

            [JsonProperty("Singrauli")]
            public Chatra Singrauli { get; set; }

            [JsonProperty("Tikamgarh")]
            public Anantapur Tikamgarh { get; set; }

            [JsonProperty("Ujjain")]
            public Anantapur Ujjain { get; set; }

            [JsonProperty("Umaria")]
            public Anantapur Umaria { get; set; }

            [JsonProperty("Vidisha")]
            public Anantapur Vidisha { get; set; }
        }

        public partial class Niwari
        {
            [JsonProperty("delta")]
            public ForeignEvacueesDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public CapitalComplexMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Mz
        {
            [JsonProperty("delta")]
            public ForeignEvacueesDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public MzDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class MzDistricts
        {
            [JsonProperty("Aizawl")]
            public Chatra Aizawl { get; set; }

            [JsonProperty("Champhai")]
            public Champhai Champhai { get; set; }

            [JsonProperty("Hnahthial")]
            public Hnahthial Hnahthial { get; set; }

            [JsonProperty("Khawzawl")]
            public Khawzawl Khawzawl { get; set; }

            [JsonProperty("Kolasib")]
            public Chatra Kolasib { get; set; }

            [JsonProperty("Lawngtlai")]
            public Champhai Lawngtlai { get; set; }

            [JsonProperty("Lunglei")]
            public Champhai Lunglei { get; set; }

            [JsonProperty("Mamit")]
            public Champhai Mamit { get; set; }

            [JsonProperty("Saiha")]
            public Champhai Saiha { get; set; }

            [JsonProperty("Saitual")]
            public Saitual Saitual { get; set; }

            [JsonProperty("Serchhip")]
            public Serchhip Serchhip { get; set; }
        }

        public partial class Champhai
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public ChatraMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }

            [JsonProperty("delta", NullValueHandling = NullValueHandling.Ignore)]
            public ForeignEvacueesDelta Delta { get; set; }
        }

        public partial class Hnahthial
        {
            [JsonProperty("delta7")]
            public MonDelta7 Delta7 { get; set; }

            [JsonProperty("total")]
            public ForeignEvacueesDelta Total { get; set; }
        }

        public partial class MonDelta7
        {
            [JsonProperty("confirmed")]
            public long Confirmed { get; set; }
        }

        public partial class Khawzawl
        {
            [JsonProperty("delta")]
            public ForeignEvacueesDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public ForeignEvacueesDelta Delta7 { get; set; }

            [JsonProperty("total")]
            public ForeignEvacueesDelta Total { get; set; }
        }

        public partial class Saitual
        {
            [JsonProperty("delta")]
            public ForeignEvacueesDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public ForeignEvacueesDelta Delta7 { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Serchhip
        {
            [JsonProperty("delta")]
            public ForeignEvacueesDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public ChatraMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Nl
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public NlDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class NlDistricts
        {
            [JsonProperty("Dimapur")]
            public Bilaspur Dimapur { get; set; }

            [JsonProperty("Kiphire")]
            public Changlang Kiphire { get; set; }

            [JsonProperty("Kohima")]
            public Bilaspur Kohima { get; set; }

            [JsonProperty("Longleng")]
            public Diu Longleng { get; set; }

            [JsonProperty("Mokokchung")]
            public Vaishali Mokokchung { get; set; }

            [JsonProperty("Mon")]
            public Mon Mon { get; set; }

            [JsonProperty("Peren")]
            public Diu Peren { get; set; }

            [JsonProperty("Phek")]
            public Changlang Phek { get; set; }

            [JsonProperty("Tuensang")]
            public Mon Tuensang { get; set; }

            [JsonProperty("Wokha")]
            public Mon Wokha { get; set; }

            [JsonProperty("Zunheboto")]
            public Vaishali Zunheboto { get; set; }
        }

        public partial class Mon
        {
            [JsonProperty("delta")]
            public MonDelta7 Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnantapurMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Or
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public OrDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class OrDistricts
        {
            [JsonProperty("Angul")]
            public Anantapur Angul { get; set; }

            [JsonProperty("Balangir")]
            public Anantapur Balangir { get; set; }

            [JsonProperty("Balasore")]
            public Anantapur Balasore { get; set; }

            [JsonProperty("Bargarh")]
            public Chatra Bargarh { get; set; }

            [JsonProperty("Bhadrak")]
            public Changlang Bhadrak { get; set; }

            [JsonProperty("Boudh")]
            public Anantapur Boudh { get; set; }

            [JsonProperty("Cuttack")]
            public Anantapur Cuttack { get; set; }

            [JsonProperty("Deogarh")]
            public Anantapur Deogarh { get; set; }

            [JsonProperty("Dhenkanal")]
            public Anantapur Dhenkanal { get; set; }

            [JsonProperty("Gajapati")]
            public Anantapur Gajapati { get; set; }

            [JsonProperty("Ganjam")]
            public Anantapur Ganjam { get; set; }

            [JsonProperty("Jagatsinghpur")]
            public Changlang Jagatsinghpur { get; set; }

            [JsonProperty("Jajpur")]
            public Changlang Jajpur { get; set; }

            [JsonProperty("Jharsuguda")]
            public Changlang Jharsuguda { get; set; }

            [JsonProperty("Kalahandi")]
            public Anantapur Kalahandi { get; set; }

            [JsonProperty("Kandhamal")]
            public Anantapur Kandhamal { get; set; }

            [JsonProperty("Kendrapara")]
            public Anantapur Kendrapara { get; set; }

            [JsonProperty("Kendujhar")]
            public Anantapur Kendujhar { get; set; }

            [JsonProperty("Khordha")]
            public Chatra Khordha { get; set; }

            [JsonProperty("Koraput")]
            public Anantapur Koraput { get; set; }

            [JsonProperty("Malkangiri")]
            public Changlang Malkangiri { get; set; }

            [JsonProperty("Mayurbhanj")]
            public Anantapur Mayurbhanj { get; set; }

            [JsonProperty("Nabarangapur")]
            public Anantapur Nabarangapur { get; set; }

            [JsonProperty("Nayagarh")]
            public Anantapur Nayagarh { get; set; }

            [JsonProperty("Nuapada")]
            public Anantapur Nuapada { get; set; }

            [JsonProperty("Puri")]
            public Anantapur Puri { get; set; }

            [JsonProperty("Rayagada")]
            public Anantapur Rayagada { get; set; }

            [JsonProperty("Sambalpur")]
            public Anantapur Sambalpur { get; set; }

            [JsonProperty("State Pool")]
            public Khawzawl StatePool { get; set; }

            [JsonProperty("Subarnapur")]
            public Serchhip Subarnapur { get; set; }

            [JsonProperty("Sundargarh")]
            public Chatra Sundargarh { get; set; }
        }

        public partial class Pb
        {
            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public Dictionary<string, Anantapur> Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Py
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public PyDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class PyDistricts
        {
            [JsonProperty("Karaikal")]
            public Chamba Karaikal { get; set; }

            [JsonProperty("Mahe")]
            public Mahe Mahe { get; set; }

            [JsonProperty("Puducherry")]
            public Chamba Puducherry { get; set; }

            [JsonProperty("Yanam")]
            public Chamba Yanam { get; set; }
        }

        public partial class Mahe
        {
            [JsonProperty("delta")]
            public ForeignEvacueesDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public ChambaMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Rj
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public RjDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class RjDistricts
        {
            [JsonProperty("Ajmer")]
            public Anantapur Ajmer { get; set; }

            [JsonProperty("Alwar")]
            public Anantapur Alwar { get; set; }

            [JsonProperty("BSF Camp")]
            public ForeignEvacuees BsfCamp { get; set; }

            [JsonProperty("Banswara")]
            public Anantapur Banswara { get; set; }

            [JsonProperty("Baran")]
            public Anantapur Baran { get; set; }

            [JsonProperty("Barmer")]
            public Anantapur Barmer { get; set; }

            [JsonProperty("Bharatpur")]
            public Anantapur Bharatpur { get; set; }

            [JsonProperty("Bhilwara")]
            public Anantapur Bhilwara { get; set; }

            [JsonProperty("Bikaner")]
            public Anantapur Bikaner { get; set; }

            [JsonProperty("Bundi")]
            public Anantapur Bundi { get; set; }

            [JsonProperty("Chittorgarh")]
            public Anantapur Chittorgarh { get; set; }

            [JsonProperty("Churu")]
            public Anantapur Churu { get; set; }

            [JsonProperty("Dausa")]
            public Anantapur Dausa { get; set; }

            [JsonProperty("Dholpur")]
            public Anantapur Dholpur { get; set; }

            [JsonProperty("Dungarpur")]
            public Anantapur Dungarpur { get; set; }

            [JsonProperty("Evacuees")]
            public ForeignEvacuees Evacuees { get; set; }

            [JsonProperty("Ganganagar")]
            public Anantapur Ganganagar { get; set; }

            [JsonProperty("Hanumangarh")]
            public Anantapur Hanumangarh { get; set; }

            [JsonProperty("Italians")]
            public ForeignEvacuees Italians { get; set; }

            [JsonProperty("Jaipur")]
            public Anantapur Jaipur { get; set; }

            [JsonProperty("Jaisalmer")]
            public Anantapur Jaisalmer { get; set; }

            [JsonProperty("Jalore")]
            public Changlang Jalore { get; set; }

            [JsonProperty("Jhalawar")]
            public Anantapur Jhalawar { get; set; }

            [JsonProperty("Jhunjhunu")]
            public Anantapur Jhunjhunu { get; set; }

            [JsonProperty("Jodhpur")]
            public Anantapur Jodhpur { get; set; }

            [JsonProperty("Karauli")]
            public Anantapur Karauli { get; set; }

            [JsonProperty("Kota")]
            public Anantapur Kota { get; set; }

            [JsonProperty("Nagaur")]
            public Anantapur Nagaur { get; set; }

            [JsonProperty("Other State")]
            public OtherState OtherState { get; set; }

            [JsonProperty("Pali")]
            public Anantapur Pali { get; set; }

            [JsonProperty("Pratapgarh")]
            public Anantapur Pratapgarh { get; set; }

            [JsonProperty("Rajsamand")]
            public Anantapur Rajsamand { get; set; }

            [JsonProperty("Sawai Madhopur")]
            public Anantapur SawaiMadhopur { get; set; }

            [JsonProperty("Sikar")]
            public Anantapur Sikar { get; set; }

            [JsonProperty("Sirohi")]
            public Anantapur Sirohi { get; set; }

            [JsonProperty("Tonk")]
            public Anantapur Tonk { get; set; }

            [JsonProperty("Udaipur")]
            public Anantapur Udaipur { get; set; }
        }

        public partial class Tn
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public TnDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class TnDistricts
        {
            [JsonProperty("Airport Quarantine")]
            public OtherState AirportQuarantine { get; set; }

            [JsonProperty("Ariyalur")]
            public Anantapur Ariyalur { get; set; }

            [JsonProperty("Chengalpattu")]
            public Anantapur Chengalpattu { get; set; }

            [JsonProperty("Chennai")]
            public Chamba Chennai { get; set; }

            [JsonProperty("Coimbatore")]
            public Anantapur Coimbatore { get; set; }

            [JsonProperty("Cuddalore")]
            public Anantapur Cuddalore { get; set; }

            [JsonProperty("Dharmapuri")]
            public Anantapur Dharmapuri { get; set; }

            [JsonProperty("Dindigul")]
            public Anantapur Dindigul { get; set; }

            [JsonProperty("Erode")]
            public Anantapur Erode { get; set; }

            [JsonProperty("Kallakurichi")]
            public Anantapur Kallakurichi { get; set; }

            [JsonProperty("Kancheepuram")]
            public Anantapur Kancheepuram { get; set; }

            [JsonProperty("Kanyakumari")]
            public Anantapur Kanyakumari { get; set; }

            [JsonProperty("Karur")]
            public Anantapur Karur { get; set; }

            [JsonProperty("Krishnagiri")]
            public Anantapur Krishnagiri { get; set; }

            [JsonProperty("Madurai")]
            public Anantapur Madurai { get; set; }

            [JsonProperty("Nagapattinam")]
            public Anantapur Nagapattinam { get; set; }

            [JsonProperty("Namakkal")]
            public Anantapur Namakkal { get; set; }

            [JsonProperty("Nilgiris")]
            public Anantapur Nilgiris { get; set; }

            [JsonProperty("Other State")]
            public TentacledOtherState OtherState { get; set; }

            [JsonProperty("Perambalur")]
            public Anantapur Perambalur { get; set; }

            [JsonProperty("Pudukkottai")]
            public Anantapur Pudukkottai { get; set; }

            [JsonProperty("Railway Quarantine")]
            public ForeignEvacuees RailwayQuarantine { get; set; }

            [JsonProperty("Ramanathapuram")]
            public Anantapur Ramanathapuram { get; set; }

            [JsonProperty("Ranipet")]
            public Anantapur Ranipet { get; set; }

            [JsonProperty("Salem")]
            public Anantapur Salem { get; set; }

            [JsonProperty("Sivaganga")]
            public Anantapur Sivaganga { get; set; }

            [JsonProperty("Tenkasi")]
            public Anantapur Tenkasi { get; set; }

            [JsonProperty("Thanjavur")]
            public Anantapur Thanjavur { get; set; }

            [JsonProperty("Theni")]
            public Anantapur Theni { get; set; }

            [JsonProperty("Thiruvallur")]
            public Anantapur Thiruvallur { get; set; }

            [JsonProperty("Thiruvarur")]
            public Anantapur Thiruvarur { get; set; }

            [JsonProperty("Thoothukkudi")]
            public Anantapur Thoothukkudi { get; set; }

            [JsonProperty("Tiruchirappalli")]
            public Anantapur Tiruchirappalli { get; set; }

            [JsonProperty("Tirunelveli")]
            public Anantapur Tirunelveli { get; set; }

            [JsonProperty("Tirupathur")]
            public Anantapur Tirupathur { get; set; }

            [JsonProperty("Tiruppur")]
            public Anantapur Tiruppur { get; set; }

            [JsonProperty("Tiruvannamalai")]
            public Anantapur Tiruvannamalai { get; set; }

            [JsonProperty("Vellore")]
            public Anantapur Vellore { get; set; }

            [JsonProperty("Viluppuram")]
            public Anantapur Viluppuram { get; set; }

            [JsonProperty("Virudhunagar")]
            public Anantapur Virudhunagar { get; set; }
        }

        public partial class TentacledOtherState
        {
            [JsonProperty("delta7")]
            public FluffyDelta Delta7 { get; set; }
        }

        public partial class Tr
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public TrDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class TrDistricts
        {
            [JsonProperty("Dhalai")]
            public Vaishali Dhalai { get; set; }

            [JsonProperty("Gomati")]
            public Vaishali Gomati { get; set; }

            [JsonProperty("Khowai")]
            public Anantapur Khowai { get; set; }

            [JsonProperty("North Tripura")]
            public Vaishali NorthTripura { get; set; }

            [JsonProperty("Sipahijala")]
            public Anantapur Sipahijala { get; set; }

            [JsonProperty("South Tripura")]
            public Vaishali SouthTripura { get; set; }

            [JsonProperty("Unokoti")]
            public Anantapur Unokoti { get; set; }

            [JsonProperty("West Tripura")]
            public Bilaspur WestTripura { get; set; }
        }

        public partial class Tt
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class Up
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public UpDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class UpDistricts
        {
            [JsonProperty("Agra")]
            public Anantapur Agra { get; set; }

            [JsonProperty("Aligarh")]
            public Anantapur Aligarh { get; set; }

            [JsonProperty("Ambedkar Nagar")]
            public Anantapur AmbedkarNagar { get; set; }

            [JsonProperty("Amethi")]
            public Anantapur Amethi { get; set; }

            [JsonProperty("Amroha")]
            public Anantapur Amroha { get; set; }

            [JsonProperty("Auraiya")]
            public Anantapur Auraiya { get; set; }

            [JsonProperty("Ayodhya")]
            public Anantapur Ayodhya { get; set; }

            [JsonProperty("Azamgarh")]
            public Anantapur Azamgarh { get; set; }

            [JsonProperty("Baghpat")]
            public Anantapur Baghpat { get; set; }

            [JsonProperty("Bahraich")]
            public Anantapur Bahraich { get; set; }

            [JsonProperty("Ballia")]
            public Anantapur Ballia { get; set; }

            [JsonProperty("Balrampur")]
            public Anantapur Balrampur { get; set; }

            [JsonProperty("Banda")]
            public Anantapur Banda { get; set; }

            [JsonProperty("Barabanki")]
            public Anantapur Barabanki { get; set; }

            [JsonProperty("Bareilly")]
            public Anantapur Bareilly { get; set; }

            [JsonProperty("Basti")]
            public Anantapur Basti { get; set; }

            [JsonProperty("Bhadohi")]
            public Anantapur Bhadohi { get; set; }

            [JsonProperty("Bijnor")]
            public Anantapur Bijnor { get; set; }

            [JsonProperty("Budaun")]
            public Anantapur Budaun { get; set; }

            [JsonProperty("Bulandshahr")]
            public Anantapur Bulandshahr { get; set; }

            [JsonProperty("Chandauli")]
            public Anantapur Chandauli { get; set; }

            [JsonProperty("Chitrakoot")]
            public Anantapur Chitrakoot { get; set; }

            [JsonProperty("Deoria")]
            public Anantapur Deoria { get; set; }

            [JsonProperty("Etah")]
            public Anantapur Etah { get; set; }

            [JsonProperty("Etawah")]
            public Anantapur Etawah { get; set; }

            [JsonProperty("Farrukhabad")]
            public Anantapur Farrukhabad { get; set; }

            [JsonProperty("Fatehpur")]
            public Anantapur Fatehpur { get; set; }

            [JsonProperty("Firozabad")]
            public Anantapur Firozabad { get; set; }

            [JsonProperty("Gautam Buddha Nagar")]
            public Anantapur GautamBuddhaNagar { get; set; }

            [JsonProperty("Ghaziabad")]
            public Anantapur Ghaziabad { get; set; }

            [JsonProperty("Ghazipur")]
            public Anantapur Ghazipur { get; set; }

            [JsonProperty("Gonda")]
            public Anantapur Gonda { get; set; }

            [JsonProperty("Gorakhpur")]
            public Anantapur Gorakhpur { get; set; }

            [JsonProperty("Hamirpur")]
            public Anantapur Hamirpur { get; set; }

            [JsonProperty("Hapur")]
            public Anantapur Hapur { get; set; }

            [JsonProperty("Hardoi")]
            public Anantapur Hardoi { get; set; }

            [JsonProperty("Hathras")]
            public Anantapur Hathras { get; set; }

            [JsonProperty("Jalaun")]
            public Anantapur Jalaun { get; set; }

            [JsonProperty("Jaunpur")]
            public Anantapur Jaunpur { get; set; }

            [JsonProperty("Jhansi")]
            public Anantapur Jhansi { get; set; }

            [JsonProperty("Kannauj")]
            public Anantapur Kannauj { get; set; }

            [JsonProperty("Kanpur Dehat")]
            public Anantapur KanpurDehat { get; set; }

            [JsonProperty("Kanpur Nagar")]
            public Anantapur KanpurNagar { get; set; }

            [JsonProperty("Kasganj")]
            public Anantapur Kasganj { get; set; }

            [JsonProperty("Kaushambi")]
            public Anantapur Kaushambi { get; set; }

            [JsonProperty("Kushinagar")]
            public Anantapur Kushinagar { get; set; }

            [JsonProperty("Lakhimpur Kheri")]
            public Anantapur LakhimpurKheri { get; set; }

            [JsonProperty("Lalitpur")]
            public Anantapur Lalitpur { get; set; }

            [JsonProperty("Lucknow")]
            public Anantapur Lucknow { get; set; }

            [JsonProperty("Maharajganj")]
            public Anantapur Maharajganj { get; set; }

            [JsonProperty("Mahoba")]
            public Anantapur Mahoba { get; set; }

            [JsonProperty("Mainpuri")]
            public Anantapur Mainpuri { get; set; }

            [JsonProperty("Mathura")]
            public Anantapur Mathura { get; set; }

            [JsonProperty("Mau")]
            public Anantapur Mau { get; set; }

            [JsonProperty("Meerut")]
            public Anantapur Meerut { get; set; }

            [JsonProperty("Mirzapur")]
            public Anantapur Mirzapur { get; set; }

            [JsonProperty("Moradabad")]
            public Anantapur Moradabad { get; set; }

            [JsonProperty("Muzaffarnagar")]
            public Anantapur Muzaffarnagar { get; set; }

            [JsonProperty("Pilibhit")]
            public Anantapur Pilibhit { get; set; }

            [JsonProperty("Pratapgarh")]
            public Anantapur Pratapgarh { get; set; }

            [JsonProperty("Prayagraj")]
            public Anantapur Prayagraj { get; set; }

            [JsonProperty("Rae Bareli")]
            public Anantapur RaeBareli { get; set; }

            [JsonProperty("Rampur")]
            public Anantapur Rampur { get; set; }

            [JsonProperty("Saharanpur")]
            public Anantapur Saharanpur { get; set; }

            [JsonProperty("Sambhal")]
            public Anantapur Sambhal { get; set; }

            [JsonProperty("Sant Kabir Nagar")]
            public Anantapur SantKabirNagar { get; set; }

            [JsonProperty("Shahjahanpur")]
            public Anantapur Shahjahanpur { get; set; }

            [JsonProperty("Shamli")]
            public Changlang Shamli { get; set; }

            [JsonProperty("Shrawasti")]
            public Anantapur Shrawasti { get; set; }

            [JsonProperty("Siddharthnagar")]
            public Anantapur Siddharthnagar { get; set; }

            [JsonProperty("Sitapur")]
            public Anantapur Sitapur { get; set; }

            [JsonProperty("Sonbhadra")]
            public Anantapur Sonbhadra { get; set; }

            [JsonProperty("Sultanpur")]
            public Anantapur Sultanpur { get; set; }

            [JsonProperty("Unnao")]
            public Anantapur Unnao { get; set; }

            [JsonProperty("Varanasi")]
            public Anantapur Varanasi { get; set; }
        }

        public partial class Ut
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public UtDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class UtDistricts
        {
            [JsonProperty("Almora")]
            public Bilaspur Almora { get; set; }

            [JsonProperty("Bageshwar")]
            public Vaishali Bageshwar { get; set; }

            [JsonProperty("Chamoli")]
            public Bilaspur Chamoli { get; set; }

            [JsonProperty("Champawat")]
            public Vaishali Champawat { get; set; }

            [JsonProperty("Dehradun")]
            public Bilaspur Dehradun { get; set; }

            [JsonProperty("Haridwar")]
            public Bilaspur Haridwar { get; set; }

            [JsonProperty("Nainital")]
            public Bilaspur Nainital { get; set; }

            [JsonProperty("Pauri Garhwal")]
            public Bilaspur PauriGarhwal { get; set; }

            [JsonProperty("Pithoragarh")]
            public Bilaspur Pithoragarh { get; set; }

            [JsonProperty("Rudraprayag")]
            public Bilaspur Rudraprayag { get; set; }

            [JsonProperty("Tehri Garhwal")]
            public Bilaspur TehriGarhwal { get; set; }

            [JsonProperty("Udham Singh Nagar")]
            public Bilaspur UdhamSinghNagar { get; set; }

            [JsonProperty("Uttarkashi")]
            public Bilaspur Uttarkashi { get; set; }
        }

        public partial class Wb
        {
            [JsonProperty("delta")]
            public PurpleDelta Delta { get; set; }

            [JsonProperty("delta7")]
            public PurpleDelta Delta7 { get; set; }

            [JsonProperty("districts")]
            public WbDistricts Districts { get; set; }

            [JsonProperty("meta")]
            public AnMeta Meta { get; set; }

            [JsonProperty("total")]
            public PurpleDelta Total { get; set; }
        }

        public partial class WbDistricts
        {
            [JsonProperty("Alipurduar")]
            public Chatra Alipurduar { get; set; }

            [JsonProperty("Bankura")]
            public Chatra Bankura { get; set; }

            [JsonProperty("Birbhum")]
            public Chatra Birbhum { get; set; }

            [JsonProperty("Cooch Behar")]
            public Chatra CoochBehar { get; set; }

            [JsonProperty("Dakshin Dinajpur")]
            public Chatra DakshinDinajpur { get; set; }

            [JsonProperty("Darjeeling")]
            public Chatra Darjeeling { get; set; }

            [JsonProperty("Hooghly")]
            public Chatra Hooghly { get; set; }

            [JsonProperty("Howrah")]
            public Chatra Howrah { get; set; }

            [JsonProperty("Jalpaiguri")]
            public Chatra Jalpaiguri { get; set; }

            [JsonProperty("Jhargram")]
            public Serchhip Jhargram { get; set; }

            [JsonProperty("Kalimpong")]
            public Chatra Kalimpong { get; set; }

            [JsonProperty("Kolkata")]
            public Chatra Kolkata { get; set; }

            [JsonProperty("Malda")]
            public Chatra Malda { get; set; }

            [JsonProperty("Murshidabad")]
            public Chatra Murshidabad { get; set; }

            [JsonProperty("Nadia")]
            public Chatra Nadia { get; set; }

            [JsonProperty("North 24 Parganas")]
            public Chatra North24Parganas { get; set; }

            [JsonProperty("Other State")]
            public OtherState OtherState { get; set; }

            [JsonProperty("Paschim Bardhaman")]
            public Chatra PaschimBardhaman { get; set; }

            [JsonProperty("Paschim Medinipur")]
            public Chatra PaschimMedinipur { get; set; }

            [JsonProperty("Purba Bardhaman")]
            public Chatra PurbaBardhaman { get; set; }

            [JsonProperty("Purba Medinipur")]
            public Chatra PurbaMedinipur { get; set; }

            [JsonProperty("Purulia")]
            public Chatra Purulia { get; set; }

            [JsonProperty("South 24 Parganas")]
            public Chatra South24Parganas { get; set; }

            [JsonProperty("Uttar Dinajpur")]
            public Chatra UttarDinajpur { get; set; }
        }
    }
}

