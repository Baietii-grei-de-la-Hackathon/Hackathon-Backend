using Newtonsoft.Json;

namespace QubHQ_Services.Dtos;


    public class BillTo
    {
        public object address { get; set; }
        public string name { get; set; }
        public object parsed_address { get; set; }
        public object vat_number { get; set; }
    }

    public class LineItem
    {
        public object date { get; set; }
        public string description { get; set; }
        public object discount { get; set; }
        public object discount_rate { get; set; }
        public object end_date { get; set; }
        public string full_description { get; set; }
        public object hsn { get; set; }
        public int id { get; set; }
        public object lot { get; set; }
        public object normalized_description { get; set; }
        public int order { get; set; }
        public object price { get; set; }
        public double quantity { get; set; }
        public object reference { get; set; }
        public object section { get; set; }
        public object sku { get; set; }
        public object start_date { get; set; }
        public List<object> tags { get; set; }
        public object tax { get; set; }
        public object tax_rate { get; set; }
        public string text { get; set; }
        public double total { get; set; }
        public string type { get; set; }
        public object unit_of_measure { get; set; }
        public object upc { get; set; }
        public object weight { get; set; }
    }

    public class Meta
    {
        public List<string> language { get; set; }
        public double ocr_score { get; set; }
        public string owner { get; set; }
        public List<Page> pages { get; set; }
        public int processed_pages { get; set; }
        public string source { get; set; }
        public List<SourceDocument> source_documents { get; set; }
        public int total_pages { get; set; }
    }

    public class Page
    {
        public int height { get; set; }
        public List<string> language { get; set; }
        public int width { get; set; }
    }

    public class ParsedAddress
    {
    }

    public class Payment
    {
        public object card_number { get; set; }
        public object display_name { get; set; }
        public object terms { get; set; }
        public object type { get; set; }
    }

    public class VeryfiItem
    {
        public object account_number { get; set; }
        public BillTo bill_to { get; set; }
        public object cashback { get; set; }
        public string category { get; set; }
        public string country_code { get; set; }
        public string created_date { get; set; }
        public string currency_code { get; set; }
        public string date { get; set; }
        public object delivery_date { get; set; }
        public object discount { get; set; }
        public string document_reference_number { get; set; }
        public string document_title { get; set; }
        public string document_type { get; set; }
        public object due_date { get; set; }
        public int duplicate_of { get; set; }
        public object external_id { get; set; }
        public int id { get; set; }
        public string img_file_name { get; set; }
        public string img_thumbnail_url { get; set; }
        public string img_url { get; set; }
        public object insurance { get; set; }
        public object invoice_number { get; set; }
        public bool is_duplicate { get; set; }
        public bool is_money_in { get; set; }
        public List<LineItem> line_items { get; set; }
        public Meta meta { get; set; }
        public object notes { get; set; }
        public string ocr_text { get; set; }
        public object order_date { get; set; }
        public Payment payment { get; set; }
        public string pdf_url { get; set; }
        public object purchase_order_number { get; set; }
        public string reference_number { get; set; }
        public object rounding { get; set; }
        public object service_end_date { get; set; }
        public object service_start_date { get; set; }
        public object ship_date { get; set; }
        public ShipTo ship_to { get; set; }
        public object shipping { get; set; }
        public string store_number { get; set; }
        public double subtotal { get; set; }
        public List<object> tags { get; set; }
        public double tax { get; set; }
        public List<object> tax_lines { get; set; }
        public object tip { get; set; }
        public double total { get; set; }
        public object total_weight { get; set; }
        public object tracking_number { get; set; }
        public string updated_date { get; set; }
        public Vendor vendor { get; set; }
    }

    public class ShipTo
    {
        public object address { get; set; }
        public object name { get; set; }
        public object parsed_address { get; set; }
    }

    public class SourceDocument
    {
        public int height { get; set; }
        public int size_kb { get; set; }
        public int width { get; set; }
    }

    public class Vendor
    {
        public object abn_number { get; set; }
        public object account_number { get; set; }
        public object address { get; set; }
        public object bank_name { get; set; }
        public object bank_number { get; set; }
        public object bank_swift { get; set; }
        public string category { get; set; }
        public object email { get; set; }
        public object fax_number { get; set; }
        public object iban { get; set; }
        public object lat { get; set; }
        public object lng { get; set; }
        public string logo { get; set; }
        public string name { get; set; }
        public ParsedAddress parsed_address { get; set; }
        public string phone_number { get; set; }
        public object raw_address { get; set; }
        public string raw_name { get; set; }
        public object reg_number { get; set; }
        public string type { get; set; }
        public object vat_number { get; set; }
        public object web { get; set; }
    }

