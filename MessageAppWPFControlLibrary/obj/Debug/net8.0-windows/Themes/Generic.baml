   M S B A M L   `   `   `  ����\  XMessageAppWPFCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:YazilimCalismasiWPF8.ConvertersYazilimCalismasiWPF8.Converters  5      U/clr-namespace:MessageAppWPFCustomControlLibrary!MessageAppWPFCustomControlLibrary  5      ;"clr-namespace:YazilimCalismasiWPF8YazilimCalismasiWPF8  5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� BasedOn*    $YazilimCalismasiWPF8.TextboxExtended �� 
TargetType �� 	Resources2  ,YazilimCalismasiWPF8.Converters.SumConverter   Key9   3YazilimCalismasiWPF8.Converters.GridLenghtConverter �� Property �� Value �� 
TargetType �Name � ColumnDefinitions ��Name	 �� RelativeSource
 �� Mode �� Path  StarConverter �� 	Converter �� ConverterParameter � RowDefinitions ��Name ��Name    HeaderFontSize    HeaderFontStyle    HeaderFontWeight    HeaderColor    Header ��Name    TextboxCornerRadius �� CornerRadius K� ZIndex    InsideHeader  BoolVisibility ��Name �� Triggers P� Property P� Value �� 
TargetName  Button.Static.Background  �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border 	 Button.Disabled.Background 
 Button.Disabled.Border  Button.Disabled.Foreground  FocusVisual! J� SnapsToDevicePixels" �� StrokeDashArray6   0MessageAppWPFCustomControlLibrary.ButtonExtended# ��Name0   *MessageAppWPFCustomControlLibrary.ChatCard$ A�Name% �� Stretch& �� ImageSource'   ChatName( �� StringFormat) (� Stretch* (�Name+ �� TextAlignment, �� Value- �� Binding. �� ElementName�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      <
Converters-clr-namespace:YazilimCalismasiWPF8.Converters  5      ?MyNamespace/clr-namespace:MessageAppWPFCustomControlLibrary  5      ,local"clr-namespace:YazilimCalismasiWPF8  5      %I  '         7��7  7  7  &	 L	    &	 o	    &	 �	    &	 �	    &	 �	    &	 �	    &		 
    &	
 A
    &	 d
    &	 �
    '  N    7  7  7  7  7  7 	 7 
 7  '  L    �� 5	      8    "   68    5
   
   ��  5      SumConverter  6&   �� 5      BoolVisibility  6+     5      StarConverter  6-   5      .�5   
   ��  � ��$ 14(�6%   �� 5   
    � �� 5      �� 5      "   6"   .R�5      � $ maingrid��5      #��z��5      #��z��5       5      �� 5      $ columnwhitespace��6/   $
��auto �6I   �� 5      $ column0��6/   $
��auto �6@   �� 5      $ column1��6/   $��5 �6@   �� 5      $ column2��6/   ��6@   �� 	 �� $
 TemplatedParent=�$ ContentWidth�8  $ 1�� 5      �� 5      $ rowwhitespace��6,   $
��auto �6C   �� 5      $
 row0��6,   $
��auto �6:   �� 5       $
 row1��6,   $��3 �6:   �� 5!      $
 row2��6,   ��6:   �� 	 �� $
 TemplatedParent=�$ ContentHeight�8  $ 1��.+�5$      �� $ header��5%      $��3��5&      $��1��5'      $��Center=�5(      #��z 5)      #��z 5*      #��z 5+      #��z 5,      #��z 5-      �� 5.      $ content��5/      $��3��50      $��3��51      #��z��52      #��z��53      #��z��54      # z 55      _�56      � 57   "   .+�58   &   �� $ insideheader��59   )   $��5,0,0,0q�5:   )   $
��Left=�5;   )   $	��Top=�5<   )   $ 1��5=   )   #��z��5>   )   #��z��5?   )   #��z��5@   )   ���#AAAAAA#��z 5B   )   y�5C   )   �� 	 �� $
 TemplatedParent=�$ IsTextEmpty�8  �� 5D   &   $ PART_ContentHost��63   5E   #   5G      5I       5K      P� 5L       �@  HeaderPozition$	 Top=�6<   . �5M      �� $ header��6%    � ��$
 Left=�6X   �� 5N      $ header��6%    � ��$ Bottom=�6V   �� 5O      $ header��6%    � ��$ 1��6M   �� 5P      $ header��6%    � ��$ 3��6P   �� 5R      $
 row1��6%    � ��$ 3 �6I   �� 5S      $ column1��6%    � ��$ 0 �6K   5T      P� 5V       �@  HeaderPozition$
 Left=�6<   . �5W      �� $ header��6%    � ��$ Right=�6X   �� 5X      $ header��6%    � ��$ 3��6M   �� 5Y      $ header��6%    � ��$ 1��6P   �� 5Z      $ header��6%    � ��$ Center=�6V   �� 5\      $
 row1��6%    � ��$ 0 �6I   �� 5]      $ column1��6%    � ��$ 5 �6K   5_      5b      5d      5e      �� 5r      $  	#FFDDDDDD��67   �� 5s      $  	#FF707070��63   �� 5t      $  	#FFBEE6FD��6:   �� 5u      $  	#FF3C7FB1��66   �� 5v      $  	#FFC4E5F6��68   �� 5w      $  	#FF2C628B��64   �� 5x      $  	#FFF4F4F4��69   �� 5y      $  	#FFADB2B5��65   �� 5z      $  	#FF838383��69   �� 5|      .�5}   
   ��  � �� 5~      �� 5      .R�5�      �� $��2q�5�      $
! true��5�      #��� ��5�      $	" 1 2R�5�      $��1��5�      5�      5�      5�      �� 5�      "  6   .�5�   
   ��  �@�FocusVisualStyle8   6-   �� 5�   
    � ��8  6'   �� 5�   
    � ��8  6(   �� 5�   
    � ��# � ��6'   �� 5�   
    � ��$ 1q�6,   �� 5�   
    � ��$ Center=�67   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��$ 1q�6$   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� $ border��5�      #��z��5�      #��z��5�      #��z��5�      $
! true��5�       5�      �� 	 �� $
 TemplatedParent=�$ ButtonCornerRadius�._�5�      �� $# contentPresenter��5�      #��z��5�      #��z��5�      #��z��5�      $|�False��5�      $
��True��5�      #! z! 5�      5�       5�      P� 5�       �@��IsDefaulted$
 true��6@   . �5�      �� $ border��6%   # � ��6P    � ��5�      P� 5�       �@J�IsMouseOver$
 true��69   . �5�      �� $ border��6%    6O   �� 	 �� $
 TemplatedParent=�$ OnMouseEnterBorderBrush� � ���� 5�      $ border��6%   8   � ��6P   5�      P� 5�       � ��$
 true��67   . �5�      �� $ border��6%    6O   �� 	 �� $
 TemplatedParent=�$ OnMouseClickBorderBrush� � ���� 5�      $ border��6%   8   � ��6P   5�      P� 5�       � {�$ false��67   . �5�      �� $ border��6%   8   � ��6O   �� 5�      $ border��6%   8   � ��6P   �� 5�      $ contentPresenter��6%   8   � ��6e   5�      5�      5�      5�      �� 5�      "  6   .�5�   
   ��  � �� 5�      �� 5�      "  6"   .R�5�      �� $ 
mainborder��5�      #��z��5�      #��z��5�      #��z��5�      #��z��5�      #��z��5�      $ 5��5�      ._�5�      � $��5q�6    5�      �� 5�   "   $
��auto �63   �� 5�   "   $
��0.5* �63   �� 5�   "   $
��auto �63   �� 5�   "   $
��0.7* �63   �� 5�   "   $��5* �63   �� 5�   "   $
��0.4* �63   �� 5�   "   $
��0.4* �63    5�      �� 5�   "   $��* �60   �� 5�   "   $��* �60   �� 5�   "   $��* �60   �� 5�   "   $��* �60   �� 5�   "   $��* �60   �� 5�   "   $��* �60   .+�5�      A� $$ ProfilePicture��5�   !   $��0��5�   !   $��6��5�   !   $��0��5�   !   $% UniformToFill=�5�   !   ���#6F6D6D$	��0.1��5�   !   ��5�   "   �� 5�   &   & 61   �� 	 �� $
 TemplatedParent=�$ 	MainImage�5�      (� 5�      $��1��5�   !   $��2��5�   !   $��2��5�   !   $��3��5�   !   $
��Left=�5�   !   .��5�   "   �� $ ChatName��5�   %   $
��Bold"�5�   %   #��z' 5�   %   $
��Wrap=�5�   %   5�      (� 5�      $��4��6&   $��2��63   .��5�   "   �� $ LastMessageSenderName��5�   %   $��4��5�   %   $��2��5   %   $
��Left=�5  %   $��Center=�5  %   $��DemiBold"�5  %   ��5  %   �� 	 �� $
 TemplatedParent=�$ LastMessageSenderName�$( {0} :��5     (� 5     $��4��5	  !   $��3��5
  !   $��Center=�5  !   $��Center=�5  !   $) Uniform=�5  !   .��5  "   �� $��4��5  %   $��3��5  %   $��1q�5  %   $��UniformToFill=�5  %   ��5  %   �� 	 �� $
 TemplatedParent=�$ LastMessageLogo�5  %   5     (� 5     $��4 ��5  !   $��4��5  !   $
��Left=�5  !   $��Center=�5  !   .��5  "   �� $��4 ��5  %   $��4��5  %   $��2��5   %   $
��Left=�5!  %   $��Center=�5"  %   ��5#  %   �� 	 �� $
 TemplatedParent=�$ LastMessage�5$     (� 5&     $* UnreadedMessages��5'  !   $��0��5(  !   $��2��5)  !   $��5��5*  !   $��2��5+  !   .��5-  "   � $��20��6'   $��20��62   .+�5/  &   A� ���#B3B3B36.   �� 51  &   $ MessageCount��52  )   $��Center=�53  )   $��Center=�54  )   $
��Bold"�55  )   
���   �$+ Center=�58  )   ��57  )   �� 	 �� $
 TemplatedParent=�$ NonReadMessageCount�58  )   59  #   5:     5<     5=      5?     �� 5@     $, 0��6^   - 6&   �� $. MessageCount��$
 Text�.a�5A     �� $ UnreadedMessages��6%    � y�$ Hidden=�6Y   5B     5E     5H     5J     5K     